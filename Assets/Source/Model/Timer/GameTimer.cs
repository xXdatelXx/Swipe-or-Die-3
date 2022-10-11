using SwipeOrDie.GameLogic;
using SwipeOrDie.View;
using SwipeOrDie.Data;
using FluentValidation;

namespace Source
{
    public class GameTimer : IGameTimer, IPauseHandler
    {
        private readonly ILose _lose;
        private readonly ITimerView _view;
        private readonly ITimeBalance _balance;
        private ITimer _timer;
        private bool _pause;

        public GameTimer(ILose lose, ITimerView timerView, ITimeBalance balance)
        {
            _lose = lose;
            _view = timerView;
            _balance = balance;

            new Validator().ValidateAndThrow(this);
        }

        public void Play()
        {
            Play(_balance.All);
        }

        public void AddTime()
        {
            Logger.Log(_timer.AccumulatedTime);
            Play(_timer.AccumulatedTime + _balance.OnAdd);
        }

        public void OnPause() => _pause = true;

        public void OnPlay() => _pause = false;

        private void Play(float time)
        {
            _timer = new Timer(time, Lose);

            _view.OnSetTime(_timer.AccumulatedTime / _balance.All * 100, _timer.Time);
            _timer.Play();
        }

        private void Lose()
        {
            Logger.Log();
            if (_pause)
                return;

            _view.OnEndTime();
            _lose.Lose();
        }

        private class Validator : AbstractValidator<GameTimer>
        {
            public Validator()
            {
                RuleFor(timer => timer._lose).NotNull();
                RuleFor(timer => timer._view).NotNull();
                RuleFor(timer => timer._balance).NotNull();
            }
        }
    }
}