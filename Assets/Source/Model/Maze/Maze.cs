using System;
using DG.Tweening;
using UnityEngine;
using FluentValidation;

public class Maze : MonoBehaviour
{
    [field: SerializeField] public Start StartPoint { get; private set; }
    private const float Speed = 30;

    private void Start()
    {
        new Validator(GetComponentInChildren<Start>(), GetComponentInChildren<Finish>())
            .ValidateAndThrow(this);
    }

    public void Enable(Transform enablePosition)
    {
        var nextPosition = enablePosition.position;
        var movingTime = Vector3.Distance(nextPosition, transform.position) / Speed;

        transform.DOMove(nextPosition, movingTime);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private class Validator : AbstractValidator<Maze>
    {
        public Validator(Start childStart, Finish childFinish)
        {
            if (childStart == null)
                throw new NullReferenceException("Dont have Start in child");
            if (childFinish == null)
                throw new NullReferenceException("Dont have Finish in child");

            RuleFor(maze => maze.StartPoint).Equal(childStart).WithMessage($"{nameof(StartPoint)} must be child");
            RuleFor(maze => maze.StartPoint).NotNull();
        }
    }
}
