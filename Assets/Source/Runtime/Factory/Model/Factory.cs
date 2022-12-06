namespace SwipeOrDie.Factory
{
    public sealed class Factory<T> : IFactory<T>
    {
        private readonly T _prefab;
        private readonly IGenericFactory<T> _factory;

        public Factory(T prefab, IGenericFactory<T> factory)
        {
            _prefab = prefab;
            _factory = factory;
        }

        public T Create() =>
            _factory.Create(_prefab);
    }
}