using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using FluentValidation;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Extension;
using Sirenix.OdinInspector;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(fileName = nameof(MazeItems))]
    public sealed class MazeItems : SerializedScriptableObject, IMazeItems
    {
        [SerializeField] private IReadOnlyList<IMazeItem> _items;
        [SerializeField] private IComplexity _complexity;
        [SerializeField, Range(0, 10)] private int _minComplexitySubtractor;
        private IMazeItem _previousItem;

        private void OnEnable()
        {
            new Validator().ValidateAndThrow(this);
        }

        public Maze Get(IScore score)
        {
            var item = Items(score).Random();
            _previousItem = item;

            return item.Maze;
        }

        private IReadOnlyList<IMazeItem> Items(IScore score)
        {
            var complexity = ComplexityRange(score);

            var items = _items
                .Where(item => complexity.InRange(item.Complexity))
                .ToList();

            return items.Count == 1 ? items : items.Where(item => item != _previousItem).ToList();
        }

        private Range ComplexityRange(IScore score)
        {
            int maxItemValue = _items.Max(i => i.Complexity);
            int scoreValue = maxItemValue < _complexity.Get(score) ? maxItemValue : _complexity.Get(score);

            return new Range(scoreValue - _minComplexitySubtractor, scoreValue);
        }

        private class Validator : AbstractValidator<MazeItems>
        {
            public Validator()
            {
                var mazeValidator = new MazeItem.Validator();

                RuleFor(collection => collection._complexity).NotNull();
                RuleFor(collection => collection._items.Count()).GreaterThan(0);
                RuleForEach(collection => collection._items)
                    .SetValidator(mazeValidator)
                    .NotNull();
            }
        }
    }
}