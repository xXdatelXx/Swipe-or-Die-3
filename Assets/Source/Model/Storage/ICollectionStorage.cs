using System.Collections.Generic;

namespace Source.Model.Storage
{
    public interface ICollectionStorage<T>
    {
        bool Exists();
        void Add(T obj);
        IEnumerable<T> Load();
    }
}