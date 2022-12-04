using System;
using Source.Model.Storage;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.ShopSystem
{
    [Serializable]
    public sealed class SkinGood : ISkinGood
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public Mesh Skin { get; private set; }
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        private IStorage<Mesh> _storage;

        public void Init(IStorage<Mesh> skinStorage) => 
            _storage = skinStorage.ThrowExceptionIfArgumentNull(nameof(skinStorage));

        public void Use() => _storage.Save(Skin);
    }
}