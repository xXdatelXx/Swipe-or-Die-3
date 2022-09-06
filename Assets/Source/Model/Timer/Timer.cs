using System;
using FluentValidation;
using Cysharp.Threading.Tasks;

namespace SwipeOrDie.GameLogic
{
    public class Timer : ITimer
    {
        private readonly Action _onEnd;
        public float Time { get; private set; }

        public Timer(float time) : this(time, null)
        {
        }

        public Timer(float time, Action onEnd)
        {
            Time = time;
            _onEnd = onEnd;

            new Validator().ValidateAndThrow(this);
        }

        public async UniTask Play()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(Time));
            _onEnd?.Invoke();
        }

        private class Validator : AbstractValidator<Timer>
        {
            public Validator()
            {
                RuleFor(timer => timer.Time).GreaterThanOrEqualTo(0);
            }
        }
    }
}