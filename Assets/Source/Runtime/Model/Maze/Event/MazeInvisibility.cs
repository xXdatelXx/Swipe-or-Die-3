using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

namespace SwipeOrDie.Model
{
    [Serializable]
    public sealed class MazeInvisibility : IMazeEvent
    {
        [SerializeField, Min(0)] private float _duration;
        [SerializeField, Min(0)] private float _startDelay;
        [SerializeField, Min(0)] private float _endDelay;
        private List<Material> _materials;

        public void Init(Maze maze) => 
            _materials = maze.GetComponentsInChildren<Renderer>().Select(r => r.material).ToList();

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