public interface IITickables
{
    void Run(ITickable tickable);
    void Stop(ITickable tickable);
}