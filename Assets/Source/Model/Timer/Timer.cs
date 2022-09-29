using System;
using FluentValidation;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SwipeOrDie.GameLogic
{
    public class Timer : ITimer
    {
        private readonly Action _onEnd;
        public float Time { get; private set; }

        public Timer(float time, Action onEnd = null)
        {
            Time = time;
            _onEnd = onEnd;

            new Validator().ValidateAndThrow(this);
        }

        public async UniTask Play()
        {
            await DOTween.To(() => Time, x => Time = x, 0, Time).AsyncWaitForCompletion();
            
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