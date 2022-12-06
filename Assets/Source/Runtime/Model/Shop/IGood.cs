using UnityEngine;

namespace SwipeOrDie.Model
{
    public interface IGood
    {
        string Id { get; }
        int Price { get; }
        Mesh Skin { get; }
        void Use();
    }
}