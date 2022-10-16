using UnityEngine;
using SwipeOrDie.GameLogic;
using Sirenix.OdinInspector;
using Source.Model.Movement.Interface;

namespace Source.Model.Enemy.Movement
{
    [RequireComponent(typeof(SphereCollider))]
    public class BulletMovement : SerializedMonoBehaviour
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

        private void Move()
        {
            _movement.Move(_position.Next(Vector2.right));
        }
    }
}