using System.Collections.Generic;
using Source.Model.Storage;
using Source.ShopSystem;
using UnityEngine;

namespace SwipeOrDie.Data
{
    public interface ISkinGoodList
    {
        List<ISkinGood> Goods { get; }
        void Init(IStorage<Mesh> skinStorage);
    }
}