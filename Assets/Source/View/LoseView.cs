using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(Animator))]
    public sealed class LoseView : SerializedMonoBehaviour, ILoseView
    {
        private Animator _animator;
        private string _loseAnimation => nameof(OnLose);

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void OnLose() => 
            _animator.SetTrigger(_loseAnimation);
    }
}