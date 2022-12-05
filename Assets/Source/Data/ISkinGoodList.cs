using System.Collections.Generic;
using SwipeOrDie.Model;
using SwipeOrDie.Storage;

namespace SwipeOrDie.Data
{
    public interface ISkinGoodList
    {
        List<ISkinGood> Goods { get; }
        void Init(MeshStorage skinStorage);
    }
}