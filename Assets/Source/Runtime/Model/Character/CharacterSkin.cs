using SwipeOrDie.Storage;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(MeshFilter))]
    public sealed class CharacterSkin : MonoBehaviour
    {
        [Inject]
        public void Construct(IStorage<Mesh> storage)
        {
            if (storage.Exists())
                GetComponent<MeshFilter>().mesh = storage.Load();
        }
    }
}