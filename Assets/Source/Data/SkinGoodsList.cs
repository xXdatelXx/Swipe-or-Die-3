using System.Collections.Generic;
using Source.Model.Storage;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(menuName = nameof(SkinGoodsList))]
    public class SkinGoodsList : ScriptableObject, ISkinGoodList
    {
        [field: SerializeReference] public List<ISkinGood> Goods { get; private set; }

        public void Init(IStorage<Mesh> skinStorage)
        {
            skinStorage.ThrowExceptionIfArgumentNull(nameof(skinStorage));
            Goods.ForEach(i => i.Init(skinStorage));
        }
    }
}