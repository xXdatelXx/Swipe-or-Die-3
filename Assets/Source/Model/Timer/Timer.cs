using System;
using FluentValidation;
using Cysharp.Threading.Tasks;

public class Timer : ITimer
{
    private Action _onEnd;
    private float _time;

    public Timer(float time) : this(time, null)
    {
    }

    public Timer(float time, Action onEnd)
    {
        _time = time;
        _onEnd = onEnd;

        new Validator().ValidateAndThrow(this);
    }

    public async UniTask Play()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_time));
        _onEnd?.Invoke();
    }

    private class Validator : AbstractValidator<Timer>
    {
        public Validator()
        {
            RuleFor(timer => timer._time).GreaterThanOrEqualTo(0);
        }
    }
}