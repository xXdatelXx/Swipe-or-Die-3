using SwipeOrDie.Model;

namespace SwipeOrDie.Data
{
    public interface IMazeItem
    {
        int Complexity { get; }
        Maze Maze { get; }
    }
}