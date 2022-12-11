namespace SwipeOrDie.Model
{
    public interface IMazeEvent
    {
        void OnMazeEnabled();
        void Init(Maze maze);
    }
}