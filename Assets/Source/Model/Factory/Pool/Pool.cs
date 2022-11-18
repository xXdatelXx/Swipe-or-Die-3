using System.Collections.Generic;
using ModestTree;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Factory.Pool
{
    public sealed class Pool<T> : IPool<T>
    {
        private readonly IFactory<T> _factory;
        private readonly Stack<T> _objects = new();

        public Pool(IFactory<T> factory) => 
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));

        public T Get() => 
            _objects.IsEmpty() ? _factory.Create() : _objects.Pop();

        public void Return(T obj)
        {
            obj.ThrowExceptionIfArgumentNull(nameof(obj));
            _objects.Push(obj);
        }
    }
}