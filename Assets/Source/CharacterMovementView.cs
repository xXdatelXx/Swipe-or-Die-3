using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent((typeof(Mesh)))]
public class CharacterMovementView : MonoBehaviour, IMovementView
{
    [SerializeField, Min(0)] private float _force;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _stopDuration;
    [SerializeField] private Vector3 _direction;
    private Vector3 _standartScale;
    private Vector3 _standartPosition;

    private void Awake()
    {
        _standartScale = transform.localScale;
        _standartPosition = transform.localPosition;
        
        OnMove(_direction);
    }

    public void OnMove(Vector3 direction)
    {
        transform.DOScale(_standartScale + direction * _force, _moveDuration);
        transform.DOMove(_standartPosition - direction * _force / 2, _moveDuration);
    }

    public void OnStop()
    {
        transform.DOScale(_standartScale, _stopDuration);
        transform.DOMove(_standartPosition, _stopDuration);
    }
}