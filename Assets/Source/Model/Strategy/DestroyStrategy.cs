using System.Threading.Tasks;
using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using SwipeOrDie.Tools;
using SwipeOrDie.View;
using UnityEngine;

namespace SwipeOrDie.Model
{
    [RequireComponent(typeof(IDestroyView))]
    public sealed class DestroyStrategy : SerializedMonoBehaviour, IDestroyStrategy
    {
        [SerializeField] private IAsyncTimer _timer;
        [SerializeField] private IDestroyView _view;

        private void Awake()
        {
            _timer.ThrowExceptionIfNull(nameof(_timer));
            _view.ThrowExceptionIfNull(nameof(_view));
        }

        public async Task Destroy()
        {
            _view.View(_timer.Time);
            await _timer.Play();
            Destroy(gameObject);
        }
    }
}