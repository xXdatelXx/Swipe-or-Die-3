using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Data
{
    public interface IMazeItems
    {
        Maze Get(IScore score);
    }
}