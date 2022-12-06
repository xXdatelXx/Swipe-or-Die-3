using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.Model
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