using System;
using Source.View.Interfaces;

namespace SwipeOrDie.GameLogic
{
    public class Score : IScore
    {
        private readonly IScoreView _view;
        public int Value { get; private set; }

        public Score(IScoreView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Append()
        {
            Value++;
            _view.OnSetScore(Value);
        }
    }
}
