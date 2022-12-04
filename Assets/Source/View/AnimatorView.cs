using Sirenix.OdinInspector;
using Source;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(Animator))]
    public sealed class AnimatorView : SerializedMonoBehaviour, IView
    { 
        [SerializeField] private string _animation;
        private Animator _animator;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void View() => 
            _animator.SetTrigger(_animation);
    }
}