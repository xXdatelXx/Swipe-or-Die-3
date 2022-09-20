using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using FluentValidation;
using SwipeOrDie.GameLogic;
using Random = UnityEngine.Random;
using Sirenix.OdinInspector;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(menuName = "MazeItems", fileName = "MazeItems")]
    public class MazeItems : SerializedScriptableObject
    {
        [SerializeField] private List<MazeItem> _items = new();
        [SerializeField] private Complexity _complexity;
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

            return _items
                .Where(item => complexity.InRange(item.Complexity))
                .ToList();
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

        private Range ComplexityRange(IScore score)
        {
            int scoreValue = _complexity.Get(score);
            return new Range(scoreValue - _minComplexitySubtractor, scoreValue);
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