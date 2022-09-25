namespace Source.Model.Timer
{
    public interface IPause
    {
        void Add(IPauseView view);
        void Pause();
    }
}