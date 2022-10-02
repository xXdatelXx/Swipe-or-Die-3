using System;
using Sirenix.OdinInspector;
using SwipeOrDie.GameLogic;
using UnityEngine;
using SwipeOrDie.Extension;

namespace Source.Model.Enemy
{
    public class BulletDestroyStrategy : SerializedMonoBehaviour
    {
        [SerializeField] private IDestroyView _destroyView;

        private void Awake()
        {
            _destroyView.TryThrowNullReferenceException();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _destroyView.Destroy(0);
            Destroy(gameObject);
        }
    }
}