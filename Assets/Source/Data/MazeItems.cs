using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using FluentValidation;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;
using Random = UnityEngine.Random;
using Sirenix.OdinInspector;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(menuName = "MazeItems", fileName = "MazeItems")]
    public class MazeItems : SerializedScriptableObject
    {
        [SerializeField] private readonly List<MazeItem> _items = new();
        [SerializeField] private readonly Complexity _complexity;
        [SerializeField, Range(0, 10)] private int _minComplexitySubtractor;
        private MazeItem _previousItem;

        private void OnEnable()
        {
            new Validator().ValidateAndThrow(this);
        }

        public Maze Get(IScore score)
        {
            var item = RandomItem(Items(score));
            _items.Remove(item);

            UpdatePreviousItem(item);

            return item.Maze;
        }

        private List<MazeItem> Items(IScore score)
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

        private EnumRange<Complexity.Value> ComplexityRange(IScore score)
        {
            var complexity = _complexity.Get(score);
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
}