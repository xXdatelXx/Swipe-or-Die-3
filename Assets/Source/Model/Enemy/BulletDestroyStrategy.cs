using System;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.Model.Enemy
{
    public class BulletDestroyStrategy : MonoBehaviour
    {
        [SerializeField] private IDestroyView _destroyView;

        private void Awake()
        {
            if (_destroyView == null)
                throw new NullReferenceException(nameof(_destroyView));
        }

        private void OnCollisionEnter(Collision collision)
        {
            _destroyView.Destroy(0);
            Destroy(gameObject);
        }
    }
}