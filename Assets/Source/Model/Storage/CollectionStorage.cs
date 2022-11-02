using System.Collections.Generic;
using System.Linq;
using SwipeOrDie.Extension;

namespace Source.Model.Storage
{
    public class CollectionStorage<T> : ICollectionStorage<T>
    {
        private readonly IStorage<IEnumerable<T>> _storage;
        private readonly List<T> _allSavedObject;

        public CollectionStorage(string name) : this(new JSonStorage<IEnumerable<T>>(name))
        { }

        public CollectionStorage(IStorage<IEnumerable<T>> storage)
        {
            _storage = storage.TryThrowArgumentNullException();
            if (_storage.Exists())
                _allSavedObject = _storage.Load().ToList();
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