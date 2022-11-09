using System.Collections.Generic;
using System.IO;
using System.Linq;
using SwipeOrDie.Extension;

namespace Source.Model.Storage
{
    public class CollectionStorage<T> : ICollectionStorage<T>
    {
        private readonly IStorage<IEnumerable<T>> _storage;
        private readonly List<T> _allSavedObject;

        public CollectionStorage(string name) : this(new BinaryStorage<IEnumerable<T>>(name))
        { }

        public CollectionStorage(IStorage<IEnumerable<T>> storage)
        {
            _storage = storage.ThrowIfArgumentNull();
            if (_storage.Exists())
            {
                Logger.Log();
                var a = _storage.Load();
                _allSavedObject = a.ToList();
            }
            else
                _allSavedObject = new();
        }

        public void Add(T obj)
        {
            _allSavedObject.Add(obj);
            //_storage.Save(_allSavedObject);
        }

        public IEnumerable<T> Load() => _storage.Load();
        public bool Exists() => _storage.Exists();
    }
    
    /*
     *
     *
     *private readonly List<T> _allSavedObject = new();
        private readonly IStorage _storage;

        public CollectionStorage(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public IEnumerable<T> Load(string key)
        {
            if (Exists(key) == false)
                throw new InvalidOperationException("Storage doesn't have save!");
            
            return _storage.Load<IEnumerable<T>>(key);
        }

        public void Save(string key, T saveObject)
        {
          _allSavedObject.Add(saveObject);
          _storage.Save(key, _allSavedObject);
        }

        public bool Exists(string key) => _storage.Exists(key);
     * 
     */
}