using SwipeOrDie.Model;

namespace SwipeOrDie.Factory
{
    public interface IMazeFactory
    {
        Maze Create(IScore score);
        void Destroy();
    }
}