using System.Threading.Tasks;
using UnityEngine;
using FluentValidation;
using SwipeOrDie.GameLogic;
using Sirenix.OdinInspector;

namespace SwipeOrDie.Strategy
{
    public sealed class MazeDestroyStrategy : SerializedMonoBehaviour, IDestroyStrategy
    {
        [SerializeField] private IAsyncTimer _destroyTimer;
        [SerializeField] private IDestroyView _view;

        private void Awake() => 
            new Validator().ValidateAndThrow(this);

        public async Task Destroy()
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