using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Factory
{
    public class DelayFactory : SerializedMonoBehaviour, IPauseHandler
    {
        [SerializeField] private MonoBehaviour _prefab;
        [SerializeField] private IAsyncTimer _timer;
        private IFactory<MonoBehaviour> _factory;
        private bool _pause;

        private void Awake()
        {
            _factory = new MonoBehaviourFactory<MonoBehaviour>(transform);
            new Validator().ValidateAndThrow(this);

            Spawn();
        }

        private async void Spawn()
        {
            while (!_pause)
            {
                await _timer.Play();
                _factory.Create(_prefab);
            }
        }

        public void OnPause() => _pause = true;

        public void OnPlay() => _pause = false;

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