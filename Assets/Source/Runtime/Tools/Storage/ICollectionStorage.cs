using System.Collections.Generic;

namespace SwipeOrDie.Storage
{
    public interface ICollectionStorage<T>
    {
        bool Exists();
        void Add(T obj);
        IEnumerable<T> Load();
    }
}