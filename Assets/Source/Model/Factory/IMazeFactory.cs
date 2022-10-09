using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Factory
{
    public interface IMazeFactory
    {
        Maze Create(IScore score);
        void Destroy();
    }
}