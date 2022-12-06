using System.Collections.Generic;
using System.Linq;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Storage
{
    public sealed class CollectionStorage<T> : ICollectionStorage<T>
    {
        private readonly IStorage<IEnumerable<T>> _storage;
        private readonly List<T> _allSavedObject;

        public CollectionStorage(string name) : this(new BinaryStorage<IEnumerable<T>>(name))
        {
        }

        public CollectionStorage(IStorage<IEnumerable<T>> storage)
        {
            _storage = storage.ThrowExceptionIfArgumentNull();
            _allSavedObject = _storage.Exists() ? _storage.Load().ToList() : new();
        }

        public void Add(T obj)
        {
            _allSavedObject.Add(obj);
            _storage.Save(_allSavedObject);
        }

        public IEnumerable<T> Load() => _storage.Load();
        public bool Exists() => _storage.Exists();
    }
}