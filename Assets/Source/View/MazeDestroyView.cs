using System.Collections.Generic;
using UnityEngine;
using SwipeOrDie.GameLogic;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;

namespace SwipeOrDie.View
{
    public sealed class MazeDestroyView : SerializedMonoBehaviour, IDestroyView
    {
        [SerializeField] private Vector3 _way;
        [SerializeField] private IAsyncTimer _delay;
        [SerializeField] private Vector3 _destroyRotate;
        [SerializeField] private Color _destroyColor;
        private IReadOnlyList<Material> _materials;

        private void Awake() => 
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material).ToList();

        public async void Destroy(float time)
        {
            await _delay.Play();

            transform.DOMove(transform.localPosition + _way, time);
            transform.DORotate(transform.eulerAngles + _destroyRotate, time);
            _materials.Select(i => i.DOColor(_destroyColor, time));
        }
    }
}
