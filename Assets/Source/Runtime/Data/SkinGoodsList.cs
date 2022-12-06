using System.Collections.Generic;
using SwipeOrDie.Extension;
using SwipeOrDie.Model;
using SwipeOrDie.Storage;
using UnityEngine;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(menuName = nameof(SkinGoodsList))]
    public sealed class SkinGoodsList : ScriptableObject, ISkinGoodList
    {
        [field: SerializeReference] public List<ISkinGood> Goods { get; private set; }
        
        public void Init(MeshStorage skinStorage)
        {
            skinStorage.ThrowExceptionIfArgumentNull(nameof(skinStorage));
            Goods.ForEach(i => i.Init(skinStorage));
        }
    }
}