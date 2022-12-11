using System.Collections.Generic;
using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using SwipeOrDie.Model;
using UnityEngine;
using Random = System.Random;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(fileName = nameof(MazeEvents))]
    public sealed class MazeEvents : SerializedScriptableObject, IMazeEvents
    {
        [SerializeField] private ILevel _level;

        [SerializeField, Title("List - levels, item1 - events, item2 - chance")]
        private List<(IMazeEvent[] array, int chance)> _events;

        private Random _random;

        private void OnEnable()
        {
            _random = new();
            new Validator().ValidateAndThrow(this);
        }

        public IMazeEvent Get(Maze maze)
        {
            var index = Mathf.Min(_level.Get(), _events.Count);
            
            if (_random.Percent() > _events[index].chance)
                return new MazeEvent();
            
            var mazeEvent = _events[index].array.Random();
            mazeEvent.Init(maze);

            return mazeEvent;
        }

        private class Validator : AbstractValidator<MazeEvents>
        {
            public Validator()
            {
                RuleFor(events => events._level).NotNull();
                RuleFor(events => events._random).NotNull();
                RuleForEach(events => events._events).NotNull().NotEmpty()
                    .ChildRules(i => i.RuleFor(j => j.chance).GreaterThanOrEqualTo(0))
                    .ChildRules(i => i.RuleFor(j => j.array).NotNull().NotEmpty())
                    .ChildRules(i => i.RuleForEach(j => j.array).NotNull());
            }
        }
    }
}