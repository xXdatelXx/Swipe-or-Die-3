using UnityEngine;

public interface IGood
{
    string Id { get; }
    int Price { get; }
    Mesh Skin { get; }
    void Use();
}