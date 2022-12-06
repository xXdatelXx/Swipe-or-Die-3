namespace SwipeOrDie.Tools
{
    public interface IPause
    {
        void Add(IPauseHandler handler);
        void Pause();
        void Play();
    }
}