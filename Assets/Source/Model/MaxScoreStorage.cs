using Source.Model.Storage;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Extension;

namespace Source.Model
{
    public class MaxScoreStorage : IMaxScore
    {
        private readonly IStorage _storage;
        private readonly IScore _score;
        private string _key => nameof(MaxScoreStorage);

        public MaxScoreStorage(IStorage storage, IScore score)
        {
            _storage = storage.TryThrowNullReferenceException();
            _score = score.TryThrowNullReferenceException();
        }

        public bool Exists() => _storage.Exists(_key);

        public IScore Load() => _storage.Load<IScore>(_key);

        public void TrySave()
        {
            if (!Exists())
            {
                _storage.Save(_key, _score);
                return;
            }

            if (Load().Value < _score.Value)
                _storage.Save(_key, _score);
        }
    }
}