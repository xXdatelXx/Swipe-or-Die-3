using JetBrains.Annotations;
using SwipeOrDie.Extension;
using SwipeOrDie.View;

namespace SwipeOrDie.Storage
{
    public sealed class PlayedGames : IPlayedGames
    {
        private readonly IStorage<int> _storage;
        [CanBeNull] private readonly IView<int> _view;

        public PlayedGames(IView<int> view = null) : this(new BinaryStorage<int>(nameof(PlayedGames)), view)
        { }

        public PlayedGames(IStorage<int> storage, IView<int> view = null)
        {
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            _view = view;
        }

        public void Add()
        {
            var games = _storage.Exists() ? _storage.Load() + 1 : 1;

            _storage.Save(games);
            _view?.View(games);
        }
    }
}