using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using Source.Model;
using UnityEngine;
using System.Linq;
using Color = SwipeOrDie.Data.Color;

namespace SwipeOrDie.GameLogic
{
    public class MazeApocaliptika : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField] private Speed _duration;
        [SerializeField] private Speed _colorForce;
        private List<Material> _materials;
        private Color _color;

        private void Awake()
        {
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material).ToList();
            _color = new(_colorForce);
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
                        .DOColor(_color.Random(), _duration.Value)
                        .SetEase(Ease.Linear);
                }

                yield return new WaitForSeconds(_duration.Value);
            }
        }
    }
}