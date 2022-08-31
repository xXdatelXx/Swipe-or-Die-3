public interface ITickable
{
    bool End { get; }
    void Tick(float deltaTime);
}