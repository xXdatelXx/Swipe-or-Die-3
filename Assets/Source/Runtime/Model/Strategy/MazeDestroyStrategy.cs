using System.Threading.Tasks;
using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.Tools;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class MazeDestroyStrategy : SerializedMonoBehaviour, IDestroyStrategy
    {
        [SerializeField] private IAsyncTimer _destroyTimer;
        [SerializeField] private IDestroyView _view;

        private void Awake() => 
            new Validator().ValidateAndThrow(this);

        public async Task Destroy()
        {
            _view.View(_destroyTimer.Time);
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