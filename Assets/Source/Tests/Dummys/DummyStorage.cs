using SwipeOrDie.Storage;

namespace Source.Tests.Dummys
{
    public sealed class DummyStorage<T> : IStorage<T>
    {
        public bool Exists() => false;

        public T Load() => default;

        public void Save(T value)
        { }
    }
}