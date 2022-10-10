using Cysharp.Threading.Tasks;

namespace SwipeOrDie.GameLogic
{
    public interface ITimer
    {
        float Time { get; }
        float AccumulatedTime { get; }
        UniTask Play();
    }
}
