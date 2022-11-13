using System;
using ModestTree;
using Source.Model.Storage;
using SwipeOrDie.Extension;
using UnityEngine;
using Zenject;

namespace Source.ShopSystem
{
    [CreateAssetMenu(fileName = nameof(SkinGood)), Serializable]
    public class SkinGood : ScriptableObject, IGood
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public Mesh Skin { get; private set; }
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        private IStorage<Mesh> _storage;

        [Inject]
        public void Construct(IStorage<Mesh> skinStorage) => 
            _storage = skinStorage.ThrowExceptionIfArgumentNull(nameof(skinStorage));

        public void Use() => _storage.Save(Skin);

        private void OnValidate() => 
            Id = Id.IsEmpty() ? name : Id;
    }
}