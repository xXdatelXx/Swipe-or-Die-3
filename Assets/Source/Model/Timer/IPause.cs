namespace Source.Model.Timer
{
    public interface IPause
    {
        void Add(IPauseHandler handler);
        void Pause();
        void Play();
    }
}