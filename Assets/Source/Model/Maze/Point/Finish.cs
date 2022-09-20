using System;
using UnityEngine;
using Zenject;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class Finish : MonoBehaviour, IFinishPoint
    {
        private LevelCreator _levelCreator;

        [Inject]
        public void Init(LevelCreator levelCreator)
        {
            _levelCreator = levelCreator ?? throw new ArgumentNullException($"{nameof(levelCreator)} == null");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.Is<ICharacter>())
                _levelCreator.Create();
        }
    }
}
