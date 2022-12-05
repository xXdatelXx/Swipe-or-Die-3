using SwipeOrDie.Storage;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(MeshFilter))]
    public sealed class CharacterSkin : MonoBehaviour
    {
        [Inject]
        public void Construct(IStorage<Mesh> storage) => 
            GetComponent<MeshFilter>().mesh = storage.Load();
    }
}