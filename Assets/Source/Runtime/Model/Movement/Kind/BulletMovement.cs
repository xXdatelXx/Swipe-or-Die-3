using UnityEngine;
using Sirenix.OdinInspector;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(SphereCollider))]
    public sealed class BulletMovement : SerializedMonoBehaviour
    {
        [SerializeField] private ISpeed _speed;
        private IPosition _position;
        private IMovement _movement;

        private void Awake()
        {
            _position = new RayPosition(transform, new Radius(GetComponent<SphereCollider>().radius));
            _movement = new InterpolationMovement(transform, _speed);

            Move();
        }

        private void Move() => 
            _movement.Move(_position.Next(Vector2.right));
    }
}