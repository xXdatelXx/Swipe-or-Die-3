using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using SwipeOrDie.Tools;
using UnityEngine;

namespace SwipeOrDie.View
{
    public sealed class MazeDestroyView : SerializedMonoBehaviour, IDestroyView
    {
        [SerializeField] private Vector3 _way;
        [SerializeField] private IAsyncTimer _delay;
        [SerializeField] private Vector3 _destroyRotate;
        [SerializeField] private Color _destroyColor;
        [SerializeField, CanBeNull] private IView _chain;
        private IReadOnlyList<Material> _materials;

        private void Awake() => 
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material).ToList();

        public async void View(float time)
        {
            _chain?.View();
            await _delay.Play();

            transform.DOMove(transform.localPosition + _way, time);
            transform.DORotate(transform.eulerAngles + _destroyRotate, time);
            _materials.Select(i => i.DOColor(_destroyColor, time));
        }
    }
}
