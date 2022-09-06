using UnityEngine;
using FluentValidation;
using SwipeOrDie.GameLogic;
using Sirenix.OdinInspector;

namespace SwipeOrDie.Strategy
{
    public class MazeDestroyStrategy : SerializedMonoBehaviour, IDestroyStrategy
    {
        [SerializeField] private readonly ITimer _destroyTimer;
        [SerializeField] private readonly IDestroyView _view;

        private void Awake()
        {
            new Validator().ValidateAndThrow(this);
        }

        public async void Destroy()
        {
            _view.Destroy(_destroyTimer.Time);
            await _destroyTimer.Play();
            Destroy(gameObject);
        }

        private class Validator : AbstractValidator<MazeDestroyStrategy>
        {
            public Validator()
            {
                RuleFor(strategy => strategy._destroyTimer).NotNull();
                RuleFor(strategy => strategy._view).NotNull();
            }
        }
    }
}