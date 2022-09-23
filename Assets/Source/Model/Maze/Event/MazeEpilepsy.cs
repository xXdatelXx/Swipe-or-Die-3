using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;
using SwipeOrDie.Data;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class MazeEpilepsy : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField, Min(0)] private float _duration;
        [SerializeField, Min(0)] private float _colorForce;
        private IReadOnlyList<Material> _materials;
        private RandomColor _randomColor;

        private void Awake()
        {
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material).ToList();
            _randomColor = new(_colorForce);
            _duration.TryThrowSubZeroException();
        }

        public void OnMazeEnabled()
        {
            StartCoroutine(ReColorize());
        }

        private IEnumerator ReColorize()
        {
            while (true)
            {
                foreach (var material in _materials)
                {
                    material
                        .DOColor(_randomColor.Next(), _duration)
                        .SetEase(Ease.Linear);
                }

                yield return new WaitForSeconds(_duration);
            }
        }
    }
}