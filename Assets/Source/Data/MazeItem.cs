using UnityEngine;
using FluentValidation;

[CreateAssetMenu(menuName = "MazeItem")]
public class MazeItem : ScriptableObject
{
    [field: SerializeField] public Complexity.Value Complexity { get; private set; }
    [field: SerializeField] public Maze Maze { get; private set; }

    public class Validator : AbstractValidator<MazeItem>
    {
        public Validator()
        {
            RuleFor(item => item.Maze).NotNull();
        }
    }
}
