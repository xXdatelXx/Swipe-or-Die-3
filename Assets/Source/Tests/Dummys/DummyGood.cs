using SwipeOrDie.Model;
using UnityEngine;

namespace Source.Tests.Dummys
{
    public sealed class DummyGood : IGood
    {
        public string Id { get; }
        public int Price { get; }
        public Mesh Skin { get; }

        public DummyGood(string id, int price)
        {
            Id = id;
            Price = price;
        }
        
        public void Use()
        { }
    }
}