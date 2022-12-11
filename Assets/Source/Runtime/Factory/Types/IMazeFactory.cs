using SwipeOrDie.Model;

namespace SwipeOrDie.Factory
{
    public interface IMazeFactory
    {
        IMaze Create();
        void Destroy();
    }
}