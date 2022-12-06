using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(Collider))]
    public sealed class Coin : SerializedMonoBehaviour
    {
        [SerializeField] private IDestroyStrategy _destroyStrategy;
        [SerializeField, Min(1)] private int _value;
        private IWallet _wallet;

        [Inject]
        public void Construct(IWallet wallet) =>
            _wallet = wallet.ThrowExceptionIfArgumentNull(nameof(wallet));

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.IsNot<ICharacter>())
                return;

            _wallet.Put(_value);
            _destroyStrategy.Destroy();

            Destroy(this);
        }
    }
}