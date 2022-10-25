using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(Animator))]
    public class DestroyView : MonoBehaviour, IDestroyView
    {
        private Animator _animator;
        private string _destroyAnimation => nameof(Destroy);

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void Destroy(float time) => 
            _animator.Play(_destroyAnimation);
    }
}