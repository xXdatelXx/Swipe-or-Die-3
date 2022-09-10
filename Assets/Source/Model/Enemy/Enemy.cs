using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.Model.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.Is<IDying>(out var dying))
                dying.Die();
        }
    }
}