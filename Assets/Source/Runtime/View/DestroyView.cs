using UnityEngine;

namespace SwipeOrDie.View
{
    [RequireComponent(typeof(Animator))]
    public sealed class DestroyView : MonoBehaviour, IDestroyView
    {
        private Animator _animator;
        private string _destroyAnimation => nameof(Destroy);

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void View(float time) => 
            _animator.Play(_destroyAnimation);
    }
}