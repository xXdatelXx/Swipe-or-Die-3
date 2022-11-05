using Source.Model.Storage;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Extension;

namespace Source.Model
{
    public class MaxScoreStorage : IMaxScore
    {
        private readonly IStorage<int> _storage;
        private readonly IScore _score;

        public MaxScoreStorage(IStorage<int> storage, IScore score)
        {
            _storage = storage.TryThrowNullReferenceException();
            _score = score.TryThrowNullReferenceException();
        }

        public int Load() =>
            _storage.Exists() ? _storage.Load() : 0;

        public void TrySave()
        {
            if (_score.Value > _storage.Load())
                _storage.Save(_score.Value);
        }
    }
}