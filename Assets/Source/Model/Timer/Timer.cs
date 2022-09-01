using System;
using System.Threading.Tasks;
using FluentValidation;

public class Timer : ITickable
{
    private float _time;
    private float _accumulatedTime;
    private readonly Action _onEnd;
    private readonly TaskCompletionSource<bool> _task;
    private bool Interactive;
    public bool End => _time <= _accumulatedTime;

    public Timer(float time) : this(time, null)
    { }

    public Timer(float time, Action onEnd)
    {
        _time = time;
        _onEnd = onEnd;
        _accumulatedTime = 0;
        _task = new();

        new Validator().ValidateAndThrow(this);
    }

    public void Tick(float deltaTime)
    {
        if (deltaTime < 0)
            throw new ArgumentOutOfRangeException($"{nameof(deltaTime)} < 0");
        if (End || !Interactive)
            return;

        _accumulatedTime += deltaTime;

        if (End)
        {
            _task.SetResult(true);
            _onEnd?.Invoke();
        }
    }

    public void Play(float time)
    {
        Interactive = true;
        _accumulatedTime = 0;
        _time = time;
    }

    public void Stop()
    {
        Interactive = false;
    }

    public async Task AweitEnd()
    {
        await _task.Task;
    }

    private class Validator : AbstractValidator<Timer>
    {
        public Validator()
        {
            RuleFor(timer => timer._time).GreaterThan(0);
        }
    }
}