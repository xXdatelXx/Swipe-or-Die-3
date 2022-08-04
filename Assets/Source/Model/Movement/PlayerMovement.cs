using System;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField] private Radius _radius;
    private IInput _input;
    private bool _moving;

    [Inject]
    public void Construct(IInput input)
    {
        if (_radius == null)
            throw new NullReferenceException("all serializeFields must dont be null");

        _input = input ?? throw new ArgumentNullException($"{input} == null");
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_moving)
            return;

        _moving = true;

        DOTween.Sequence()
            .Append
            (
                transform.DOMove(Position(_input.Direction),
                Vector3.Distance(transform.position, Position(_input.Direction)) / _speed)
            )
            .onComplete += () => _moving = false;
    }

    private Vector2 Position(Vector2 direction)
    {
        // нельзя двигаться по диагонале 
        if (direction.x is not 0 or 1 && direction.y is not 0 or 1)
            return transform.position;

        Physics.Raycast(transform.position, direction, out RaycastHit hit);

        if (hit.point == Vector3.zero)
            return transform.position;

        return hit.point + _radius.Indent(direction);
    }
}
