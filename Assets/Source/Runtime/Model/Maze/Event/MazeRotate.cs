using DG.Tweening;
using UnityEngine;
using System;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Model
{
    [Serializable]
    public sealed class MazeRotate : IMazeEvent
    {
        [SerializeField, Min(0)] private float _duration;
        private Maze _maze;

        public void Init(Maze maze) => _maze = maze.ThrowExceptionIfArgumentNull(nameof(maze));
        public void OnMazeEnabled() => Rotate();

        private void Rotate()
        {
            _maze.transform
                .DOCircleRotateZ(_duration)
                .Looped()
                .SetEase(Ease.Linear);
        }
    }
}