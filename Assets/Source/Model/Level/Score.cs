using Source.View.Interfaces;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class Score : IScore
    {
        private readonly IScoreView _view;
        public int Value { get; private set; }

        public Score(IScoreView view)
        {
            _view = view.TryThrowNullReferenceException();
        }

        public void Append()
        {
            Value++;
            _view.OnSetScore(Value);
        }
    }
}
