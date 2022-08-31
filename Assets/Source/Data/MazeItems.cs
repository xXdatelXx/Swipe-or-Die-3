using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using FluentValidation;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "MazeItems", fileName = "MazeItems")]
public class MazeItems : ScriptableObject
{
    [SerializeField] private List<MazeItem> _items = new();
    [SerializeField] private Complexity _complexity;
    [SerializeField, Range(0, 10)] private int _minComplexitySubtractor;
    private MazeItem _previousItem;

    private void OnEnable()
    {
        new Validator().ValidateAndThrow(this);
    }

    public Maze Get(Score score)
    {
        var item = RandomItem(Items(score));
        _items.Remove(item);

        UpdatePreviousItem(item);

        return item.Maze;
    }

    private List<MazeItem> Items(Score score)
    {
        var complexity = ComplexityRange(score);

        var items = _items
            .Where(item => item.Complexity == complexity.Min || item.Complexity == complexity.Max)
            .ToList();

        return items ?? throw new InvalidOperationException();
    }

    private MazeItem RandomItem(List<MazeItem> collection)
    {
        return collection[Random.Range(0, collection.Count)];
    }

    private void UpdatePreviousItem(MazeItem item)
    {
        if (_previousItem != null)
            _items.Add(_previousItem);

        _previousItem = item;
    }

    private EnumRange<Complexity.Value> ComplexityRange(Score score)
    {
        var complexity = _complexity.Get(score.Value);
        return new EnumRange<Complexity.Value>(complexity.Next(-_minComplexitySubtractor), complexity);
    }

    private class Validator : AbstractValidator<MazeItems>
    {
        public Validator()
        {
            RuleFor(collection => collection._complexity).NotNull();
            RuleFor(collection => collection._items.Count()).GreaterThan(0);

            var mazeValidator = new MazeItem.Validator();

            RuleForEach(collection => collection._items)
                .NotNull()
                .SetValidator(mazeValidator);
        }
    }
}