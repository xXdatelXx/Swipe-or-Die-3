using System;
using System.Threading.Tasks;
using FluentValidation;

public struct Timer : ITickable
{
    private readonly float _time;
    private float _accumulatedTime;
    private readonly Action _onEnd;
    private readonly TaskCompletionSource<bool> _end;
    public bool End => _time <= _accumulatedTime;

    public Timer(float time) : this(time, null)
    { }

    public Timer(float time, Action onEnd)
    {
        _time = time;
        _onEnd = onEnd;
        _accumulatedTime = 0;
        _end = new();

        new Validator().ValidateAndThrow(this);
    }

    public void Tick(float deltaTime)
    {
        if (deltaTime < 0)
            throw new ArgumentOutOfRangeException($"{nameof(deltaTime)} < 0");
        if (End)
            return;

        _accumulatedTime += deltaTime;

        if (End)
        {
            _end.SetResult(true);
            _onEnd?.Invoke();
        }
    }

    public async Task AweitEnd()
    {
        await _end.Task;
    }

    private class Validator : AbstractValidator<Timer>
    {
        public Validator()
        {
            RuleFor(timer => timer._time).GreaterThan(0);
        }
    }
}