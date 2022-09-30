using DG.Tweening;
using Sirenix.OdinInspector;
using Source.Model;
using SwipeOrDie.Extension;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class MazeRotate : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField] private ISpeed _duration;
        private readonly Vector3 _rotateAngle = new Vector3().HalfCircle();

        public void OnMazeEnabled()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform
                .DORotate(_rotateAngle, _duration.Value)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        }
    }
}