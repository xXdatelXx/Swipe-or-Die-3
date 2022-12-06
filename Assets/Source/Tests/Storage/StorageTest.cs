using SwipeOrDie.Extension;
using SwipeOrDie.Storage;

namespace Source.Tests.Storage
{
    public sealed class StorageTest<T>
    {
        private readonly IStorage<T> _storage;
        private readonly T _value;
        private readonly IFileDestructor _destructor;

        public StorageTest(IStorage<T> storage, T value, IFileDestructor destructor)
        {
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));
            _value = value.ThrowExceptionIfArgumentNull();
            _destructor = destructor.ThrowExceptionIfArgumentNull(nameof(destructor));
        }

        public bool SavesCorrectly()
        {
            _storage.Save(_value);
            var result = Equals(_storage.Load(), _value);
            _destructor.Destruct();
            
            return result;
        }
    }
}