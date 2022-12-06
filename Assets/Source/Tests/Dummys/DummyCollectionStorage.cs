using System.Collections.Generic;
using SwipeOrDie.Storage;

namespace Source.Tests.Dummys
{
    public sealed class DummyCollectionStorage<T> : ICollectionStorage<T>
    {
        public bool Exists() => false;

        public IEnumerable<T> Load() => default;
        
        public void Add(T obj)
        { }
    }
}