using SwipeOrDie.Extension;
using SwipeOrDie.Storage;
using UnityEngine;

namespace SwipeOrDie.Data
{
    public sealed class Volume : IVolume, INegateStorage
    {
        private readonly INegateStorage _storage;
        public bool Value { get; private set; }

        public Volume(INegateStorage storage) =>
            _storage = storage.ThrowExceptionIfArgumentNull(nameof(storage));

        public void Negate()
        {
            _storage.Negate();
            
            Value = _storage.Value;
            AudioListener.volume = Value ? 1 : 0;
        }
    }
}