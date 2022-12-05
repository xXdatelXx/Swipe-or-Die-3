using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.Storage
{
    public sealed class MeshStorage : IStorage<Mesh>
    {
        private readonly IStorage<byte[]> _storage;
        
        public MeshStorage(string name) : this(new BinaryStorage<byte[]>(name))
        { }
        
        public MeshStorage(IStorage<byte[]> storage) => 
            _storage = storage.ThrowExceptionIfArgumentNull();
        
        public void Save(Mesh mesh) => _storage.Save(mesh.Serialize());

        public Mesh Load() => _storage.Load().DeSerialize();
        
        public bool Exists() => _storage.Exists();
    }
}