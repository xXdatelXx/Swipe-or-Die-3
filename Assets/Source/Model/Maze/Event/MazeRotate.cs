using DG.Tweening;
using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class MazeRotate : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField, Min(0)] private float _duration;
        private Sequence _playSequence;

        private void Awake() => _duration.TryThrowSubZeroException();

        public void OnMazeEnabled() => Rotate();

        private void Rotate()
        {
            transform
                .DOCircleRotateZ(_duration) 
                .Looped()
                .SetEase(Ease.Linear);
        }
    }
}