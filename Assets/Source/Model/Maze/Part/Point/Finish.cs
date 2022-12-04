using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Source;
using UnityEngine;
using Zenject;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public sealed class Finish : SerializedMonoBehaviour, IFinishPoint
    {
        [SerializeField] private List<int> _collisionAngles = new() { 0, 90, -90, 180 };
        [SerializeField] private IView _view;
        private ILevelCreator _levelCreator;

        [Inject]
        public void Init(ILevelCreator levelCreator)
        {
            _levelCreator = levelCreator.ThrowExceptionIfNull();

            if (_collisionAngles.Count == 0)
                throw new NullReferenceException($"{nameof(_collisionAngles)}.Count == 0");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.IsNot<ICharacter>())
                return;

            if (TrueAngle(collision))
                OnFinish();
        }

        private bool TrueAngle(Collision collision)
        {
            var collisionAngle = collision.Angle(transform);
            return _collisionAngles.Any(angle => angle == collisionAngle);
        }

        private void OnFinish()
        {
            _levelCreator.Create();
            _view.View();
        }
    }
}