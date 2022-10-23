using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class MazeInvisibility : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField, Min(0)] private float _duration;
        [SerializeField, Min(0)] private float _startDelay;
        [SerializeField, Min(0)] private float _endDelay;
        private IEnumerable<Material> _materials;

        private void Awake()
        {
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material);

            _duration.TryThrowSubZeroException();
            _startDelay.TryThrowSubZeroException();
            _endDelay.TryThrowSubZeroException();
        }

        public void OnMazeEnabled() => ReColorize();

        private void ReColorize()
        {
            foreach (var material in _materials)
            {
                DOTween.Sequence()
                   .AppendInterval(_startDelay)
                   .Append(material.DOFade(0, _duration))
                   .AppendInterval(_endDelay)
                   .SetLoops(-1, LoopType.Yoyo);
            }
        }
    }
}