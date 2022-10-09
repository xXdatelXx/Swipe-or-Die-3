using JetBrains.Annotations;
using Source.View.Interfaces;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class Score : IScore
    {
        [CanBeNull] private readonly IScoreView _view;
        public int Value { get; private set; }

        public Score(IScoreView view = null)
        {
            _view = view;
        }

        public void Append()
        {
            Value++;
            _view?.OnSetScore(Value);
        }
    }
}
