using JetBrains.Annotations;
using SwipeOrDie.Extension;
using SwipeOrDie.View;

namespace SwipeOrDie.Storage
{
    public sealed class NegateStorage : INegateStorage
    {
        private readonly IStorage<bool> _storage;
        [CanBeNull] private readonly IView<bool> _view;
        public bool Value => !_storage.Exists() || _storage.Load();

        public NegateStorage(IStorage<bool> storage, IView<bool> view = null)
        {
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            _view = view;
            
            _view?.View(Value);
        }

        public void Negate()
        {
            var newValue = !Value;
            
            _storage.Save(newValue);
            _view?.View(newValue);
        }
    }
}