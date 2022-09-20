using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using Source.Model;
using System.Linq;

namespace SwipeOrDie.GameLogic
{
    public class MazeInvisibility : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField] private Speed _duration;
        [SerializeField] private Speed _startDelay;
        [SerializeField] private Speed _endDelay;
        private IEnumerable<Material> _materials;

        private void Awake()
        {
            _materials = GetComponentsInChildren<Renderer>().Select(r => r.material);
        }

        public void OnMazeEnabled()
        {
            ReColorize();
        }

        private void ReColorize()
        {
            foreach (var material in _materials)
            {
                 DOTween.Sequence()
                    .AppendInterval(_startDelay.Value)
                    .Append(material.DOFade(0, _duration.Value))
                    .AppendInterval(_endDelay.Value)
                    .SetLoops(-1, LoopType.Yoyo);
            }
        }
    }
}