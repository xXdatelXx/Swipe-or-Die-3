using Cysharp.Threading.Tasks;

namespace SwipeOrDie.GameLogic
{
    public interface IAsyncTimer
    {
        float Time { get; }
        UniTask Play();
    }
}