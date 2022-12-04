using Source.Model.Storage;
using UnityEngine;

public interface ISkinGood : IGood
{
    void Init(IStorage<Mesh> skinStorage);
}