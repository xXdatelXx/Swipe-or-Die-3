using System;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using System.Linq;
using SwipeOrDie.Data;

namespace SwipeOrDie.Model
{
    [Serializable]
    public struct MazeEpilepsy : IMazeEvent
    {
        [SerializeField, Min(0)] private float _startDelay;
        [SerializeField, Min(0)] private float _duration;
        [SerializeField] private IRandomColor _randomColor;
        private List<Material> _materials;
        private Maze _maze;

        public void OnMazeEnabled() => _maze.StartCoroutine(ReColorize());

        public void Init(Maze maze)
        {
            _materials = maze.GetComponentsInChildren<Renderer>().Select(r => r.material).ToList();
            _maze = maze;
        }

        private IEnumerator ReColorize()
        {
            var delay = new WaitForSeconds(_duration);
            
            yield return new WaitForSeconds(_startDelay);

            while (true)
            {
                foreach (var i in _materials)
                    i.DOColor(_randomColor.Next(), _duration).SetEase(Ease.Linear);

                yield return delay;
            }
        }
    }
}