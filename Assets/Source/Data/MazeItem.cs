using System;
using UnityEngine;
using FluentValidation;
using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Data
{
    [Serializable]
    public class MazeItem : IMazeItem
    {
        [field: SerializeField] public int Complexity { get; private set; }
        [field: SerializeField] public Maze Maze { get; private set; }

        public class Validator : AbstractValidator<IMazeItem>
        {
            public Validator()
            {
                RuleFor(item => item.Maze).NotNull();
            }
        }
    }
}