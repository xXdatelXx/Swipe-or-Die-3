using UnityEngine;

public interface IGood
{
    int Price { get; }
    Mesh Skin { get; }
    void Use();
}