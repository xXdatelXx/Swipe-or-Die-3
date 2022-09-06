using Cysharp.Threading.Tasks;

namespace SwipeOrDie.GameLogic
{
    public interface ITimer
    {
        float Time { get; }
        UniTask Play();
    }
}
