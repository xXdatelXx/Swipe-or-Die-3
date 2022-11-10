using System;
using Source.Model.Storage;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.ShopSystem
{
    [CreateAssetMenu(fileName = nameof(SkinGood)), Serializable]
    public class SkinGood : ScriptableObject, IGood
    {
        [field: SerializeField] public Mesh Skin { get; private set; }
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        private readonly IStorage<byte[]> _storage = new BinaryStorage<byte[]>(nameof(Skin));

        public void Use() => _storage.Save(Skin.Serialize());
    }
}