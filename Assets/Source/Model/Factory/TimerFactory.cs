using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Factory
{
    public class TimerFactory : SerializedMonoBehaviour
    {
        [SerializeField, Range(0, 10)] private readonly float _reload;
        [SerializeField] private readonly MonoBehaviour _prefab;
        [SerializeField] private readonly ITimer _timer;
        private IFactory<MonoBehaviour> _factory;

        private void Awake()
        {
            _factory = new MonoBehaviourFactory<MonoBehaviour>(transform);
        }

        private async void Update()
        {
            await _timer.Play();
            _factory.Create(_prefab);
        }

        private class Validator : AbstractValidator<TimerFactory>
        {
            public Validator()
            {
                RuleFor(factory => factory._reload).GreaterThanOrEqualTo(0);
                RuleFor(factory => factory._prefab).NotNull();
                RuleFor(factory => factory._timer).NotNull();
            }
        }
    }
}