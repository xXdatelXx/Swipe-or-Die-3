using System;
using UnityEngine;
using SwipeOrDie.GameLogic;
using DG.Tweening;
using Sirenix.OdinInspector;
using SwipeOrDie.Extension;

namespace SwipeOrDie.View
{
    public class MazeDestroyView : SerializedMonoBehaviour, IDestroyView
    {
        [SerializeField] private Transform _destroyPoint;
        [SerializeField] private ITimer _delayTimer;
        [SerializeField] private Vector3 _destroyRotate;
        [SerializeField] private Color _destroyColor;
        private Material _material;

        private void Awake()
        {
            _destroyPoint.TryThrowNullReferenceException();
            _material = GetComponent<Material>();
        }

        public async void Destroy(float time)
        {
            await _delayTimer.Play();

            transform.DOMove(_destroyPoint.position, time);
            transform.DORotate(_destroyRotate, time);
            _material.DOColor(_destroyColor, time);
        }
    }
}
