using JetBrains.Annotations;
using SwipeOrDie.Extension;
using SwipeOrDie.Storage;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class MaxScoreStorage : IMaxScore
    {
        private readonly IStorage<int> _storage;
        private readonly IScore _score;
        [CanBeNull] private readonly IScoreView _view;

        public MaxScoreStorage(BinaryStorage<int> storage, IScore score, IScoreView view = null)
        {
            _storage = storage.ThrowExceptionIfNull();
            _score = score.ThrowExceptionIfNull();
            _view = view;
            _view?.View(Load());
        }

        public int Load() =>
            _storage.Exists() ? _storage.Load() : 0;

        public void TrySave()
        {
            var score = _score.Value;
            if (score > Load())
            {
                _storage.Save(score);
                _view?.View(score);
            }
        }
    }
}