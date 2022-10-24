using Source.Model.Storage;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.Shop
{
    public class SkinGood : IGood
    {
        private readonly IStorage _storage;
        private readonly MeshRenderer _skin;
        public int Price { get; }

        public SkinGood(IStorage storage, MeshRenderer skin, int price)
        {
            _storage = storage.TryThrowNullReferenceException();
            _skin = skin.TryThrowNullReferenceException();
            Price = price.TryThrowSubZeroException();
        }

        public void Use() => 
            _storage.Save(nameof(SkinGood), _skin);
    }
}