using SwipeOrDie.Extension;
using SwipeOrDie.Factory;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.Model.Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private void OnCollisionEnter(Collision collision)
        {
            Logger.Log(collision.Is<IDying>());
            if (collision.Is<IDying>(out var dying))
                dying.Die();
        }
    }
}