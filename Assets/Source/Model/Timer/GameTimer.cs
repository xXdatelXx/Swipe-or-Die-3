using SwipeOrDie.GameLogic;
using SwipeOrDie.View;
using SwipeOrDie.Data;
using FluentValidation;
using SwipeOrDie.Factory;

namespace Source
{
    public class GameTimer : IGameTimer, IPauseHandler
    {
        private readonly ILose _lose;
        private readonly ITimerView _view;
        private readonly ITimeBalance _balance;
        private ITimer _timer;
        private bool _pause;

        public GameTimer(ILose lose, ITimerView timerView, ITimeBalance balance, ITimerFactory timerFactory)
        {
            _lose = lose;
            _view = timerView;
            _balance = balance;
            _timer = timerFactory.Create(_balance.All);

            new Validator().ValidateAndThrow(this);
        }

        public async void Play()
        {
            _view.OnSetTime(_balance.All);
            await _timer.Play();

            if (_pause)
                return;

            _view.OnEndTime();
            _lose.Lose();
        }

        public void AddTime()
        {
            _timer.Effect(-_balance.OnAdd);
            _view.OnSetTime(_balance.All - _timer.AccumulatedTime, 100 - (_timer.AccumulatedTime / _balance.All * 100));
        }

        public void OnPause() => _pause = true;

        public void OnPlay() => _pause = false;

        private class Validator : AbstractValidator<GameTimer>
        {
            public Validator()
            {
                RuleFor(timer => timer._lose).NotNull();
                RuleFor(timer => timer._view).NotNull();
                RuleFor(timer => timer._balance).NotNull();
                RuleFor(timer => timer._timer).NotNull();
            }
        }
    }
}