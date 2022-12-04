using System.Collections.Generic;
using ModestTree;
using Source;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Factory.Pool
{
    public sealed class Pool<T> : IPool<T> where T : IPoolObject
    {
        private readonly IFactory<T> _factory;
        private readonly Stack<T> _objects = new();

        public Pool(IFactory<T> factory, Stack<T> objects = null)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _objects = objects ?? new();
        }

        public T Get()
        {
            var obj = _objects.IsEmpty() ? _factory.Create() : _objects.Pop();
            obj.Enable();

            return obj;
        }

        public void Return(T obj)
        {
            obj.ThrowExceptionIfArgumentNull(nameof(obj));
            
            obj.Disable();
            _objects.Push(obj);
        }
    }
}