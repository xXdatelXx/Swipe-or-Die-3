using UnityEngine;
using SwipeOrDie.GameLogic;
using Sirenix.OdinInspector;
using Source.Model.Movement.Interface;

namespace Source.Model.Enemy.Movement
{
    public class BulletMovement : SerializedMonoBehaviour
    {
        [SerializeField] private ISpeed _speed;
        [SerializeField] private IPosition _position;
        private IMovement _movement;

        private void Awake()
        {
            _movement = new InterpolationMovement(transform, _speed);
            Move();
        }

        private async void Move()
        {
            await _movement.Move(_position.Next(transform.forward));
        }
    }
}