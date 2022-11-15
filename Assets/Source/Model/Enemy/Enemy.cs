using SwipeOrDie.Extension;
using SwipeOrDie.Factory;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.Model.Enemy
{
    public sealed class Enemy : MonoBehaviour, IEnemy
    {
        private void OnCollisionEnter(Collision collision)
        {
            collision.Is<IDying>(out var dying);
            dying?.Die();
        }
    }
}