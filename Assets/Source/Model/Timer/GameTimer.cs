using SwipeOrDie.GameLogic;
using SwipeOrDie.View;

namespace Source
{
    public class GameTimer : IGameTimer
    {
        private readonly ILose _lose;
        private readonly ITimerView _timerView;
        private const float AddedTimeOnFinish = 2;
        private const float AllTime = 30;
        private ITimer _timer;

        public GameTimer(ILose lose, ITimerView timerView)
        {
            _lose = lose;
            _timerView = timerView;
        }

        public void AddTime()
        {
            Play(_timer.Time + AddedTimeOnFinish);
        }

        public void Play()
        {
            Play(AllTime);
        }

        private void Play(float time)
        {
            _timer = new Timer(time, Lose);

            _timerView.OnSetTime(_timer.Time * AllTime / 100);
            _timer.Play();
        }

        private void Lose()
        {
            _timerView.OnEndTime();
            _lose.Lose();
        }
    }
}