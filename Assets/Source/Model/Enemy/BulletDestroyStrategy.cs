using Sirenix.OdinInspector;
using SwipeOrDie.GameLogic;
using UnityEngine;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic.Part;

namespace Source.Model.Enemy
{
    public class BulletDestroyStrategy : SerializedMonoBehaviour
    {
        [SerializeField] private IDestroyView _destroyView;

        private void Awake() => 
            _destroyView.ThrowExceptionIfNull();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.Is<IBorder>() || collision.Is<IDying>())
            {
                _destroyView.Destroy(0);
                Destroy(gameObject);
            }
        }
    }
}