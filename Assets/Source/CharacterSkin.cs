using Source.Model.Storage;
using UnityEngine;
using Zenject;

namespace Source
{
    [RequireComponent(typeof(MeshFilter))]
    public sealed class CharacterSkin : MonoBehaviour
    {
        [Inject]
        public void Construct(IStorage<Mesh> storage) => 
            GetComponent<MeshFilter>().mesh = storage.Load();
    }
}