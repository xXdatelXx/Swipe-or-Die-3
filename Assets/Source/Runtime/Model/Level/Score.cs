using JetBrains.Annotations;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class Score : IScore
    {
        [CanBeNull] private readonly IScoreView _view;
        public int Value { get; private set; }

        public Score(IScoreView view = null) => 
            _view = view;

        public void Append()
        {
            Value++;
            _view?.View(Value);
        }
    }
}
