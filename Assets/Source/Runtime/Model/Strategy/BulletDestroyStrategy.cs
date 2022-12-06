using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using SwipeOrDie.Extension;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class BulletDestroyStrategy : SerializedMonoBehaviour
    {
        [SerializeField] private bool _animated;
        [SerializeField, CanBeNull, ShowIf("_animated")] private IView _destroyView;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.Is<IBorder>() || collision.Is<IDying>())
            {
                _destroyView?.View();
                Destroy(gameObject);
            }
        }
    }
}