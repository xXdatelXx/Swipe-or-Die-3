using System;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    [RequireComponent(typeof(Animator))]
    public class GameView : MonoBehaviour, IGameView
    {
        private Animator _animator;
        private string _play => "Play";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Play()
        {
            _animator.SetTrigger(_play);
        }
    }
}