using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Factory
{
    public class TimerFactory : SerializedMonoBehaviour
    {
        [SerializeField] private MonoBehaviour _prefab;
        [SerializeField] private ITimer _timer;
        private IFactory<MonoBehaviour> _factory;

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
                _factory.Create(_prefab);
            }
        }

        private class Validator : AbstractValidator<TimerFactory>
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