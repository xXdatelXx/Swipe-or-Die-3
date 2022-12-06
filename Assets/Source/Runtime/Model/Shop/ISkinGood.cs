using SwipeOrDie.Storage;
using UnityEngine;

namespace SwipeOrDie.Model
{
    public interface ISkinGood : IGood
    {
        void Init(IStorage<Mesh> skinStorage);
    }
}