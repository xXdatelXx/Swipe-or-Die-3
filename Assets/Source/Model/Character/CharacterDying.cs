using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class CharacterDying : SerializedMonoBehaviour, IDying
    {
        [SerializeField] private readonly IDyingView _view;

        private void OnEnable()
        {
            if (_view == null)
                throw new NullReferenceException($"{nameof(_view)} == null");
        }

        public void Die()
        {
            _view.OnDie();   
        }
    }
}