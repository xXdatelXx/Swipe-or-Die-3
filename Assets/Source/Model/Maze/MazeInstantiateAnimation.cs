using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.Model
{
    public sealed class MazeInstantiateAnimation : MonoBehaviour, IMazeInstantiateAnimation
    {
        private const float _duration = 0.5f;
        private IEnumerable<Material> _materials;
        
        private void Awake() => 
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material);

        private void Start() => Animate();

        public void Animate()
        {
            UnFade();
            Scale();
            Rotate();
        }

        private void UnFade()
        {
            foreach (var material in _materials)
            {
                var color = material.color;
                material.color = Color.clear;
                material.DOColor(color, _duration);
            }
        }

        private void Scale()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, _duration);
        }

        private void Rotate()
        {
            transform.eulerAngles = new Vector3().HalfCircle();
            transform.DORotate(Vector3.zero, _duration);
        }
    }
}