using SwipeOrDie.Factory;
using UnityEngine;

namespace SwipeOrDie.Storage
{
    public abstract class CollisionEffect : MonoBehaviour, IPoolObject
    {
        [field: SerializeField] public Types Type { get; private set; }

        public enum Types
        {
            Null,
            Movement,
            BulletDestroy,
            CharacterDestroy
        }
        
        public void SetPosition(Vector3 position) => 
            transform.position = position;

        public abstract void Enable();
        public abstract void Disable();
    }
}