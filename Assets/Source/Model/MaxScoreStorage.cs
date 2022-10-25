using Source.Model.Storage;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Extension;

namespace Source.Model
{
    public class MaxScoreStorage : IMaxScore
    {
        private readonly IStorage<IScore> _storage;
        private readonly IScore _score;

        public MaxScoreStorage(IStorage<IScore> storage, IScore score)
        {
            _storage = storage.TryThrowNullReferenceException();
            _score = score.TryThrowNullReferenceException();
        }

        public bool Exists() => _storage.Exists();

        public IScore Load() => _storage.Load();

        public void TrySave()
        {
        }
    }
}