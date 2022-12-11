using UnityEngine;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Model
{
    //TODO: Maybe the abstraction needs to be reworked (Maze, IMaze)
    [RequireComponent(typeof(IDestroyStrategy)), SelectionBase]
    public sealed class StandardMaze : Maze
    {
        private IMazeEvent _event;
        private IDestroyStrategy _destroyStrategy;
        private IMovement _movement;

        private void Awake() => 
            _destroyStrategy = GetComponent<IDestroyStrategy>();

        public override void Init(IMovement movement, IMazeEvent mazeEvent)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _event = mazeEvent.ThrowExceptionIfArgumentNull(nameof(mazeEvent));
        }

        public override void Enable(Transform enablePosition)
        {
            _event.OnMazeEnabled();
            _movement.Move(enablePosition.position);
        }

        public override void Destroy() =>
            _destroyStrategy.Destroy();
    }
}