using FluentValidation;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Source;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Factory
{
    public sealed class DelayFactory : SerializedMonoBehaviour, IPauseHandler
    {
        [SerializeField] private MonoBehaviour _prefab;
        [SerializeField] private IAsyncTimer _timer;
        [SerializeField, CanBeNull] private IView _view;
        private IGenericFactory<MonoBehaviour> _factory;
        private bool _pause;

        private void Awake()
        {
            _factory = new MonoBehaviourFactory<MonoBehaviour>(transform);
            new Validator().ValidateAndThrow(this);

            Spawn();
        }

        private async void Spawn()
        {
            while (true)
            {
                await _timer.Play();

                if (!_pause)
                {
                    _factory.Create(_prefab);
                    _view?.View();
                }
            }
        }

        public void Enable() => _pause = false;
        public void Disable() => _pause = true;
        private void OnDestroy() => Disable();

        private class Validator : AbstractValidator<DelayFactory>
        {
            public Validator()
            {
                RuleFor(factory => factory._prefab).NotNull();
                RuleFor(factory => factory._timer).NotNull();
                RuleFor(factory => factory._factory).NotNull();
            }
        }
    }
}