using Cysharp.Threading.Tasks;

namespace SwipeOrDie.Tools
{
    public interface IAsyncTimer
    {
        float Time { get; }
        UniTask Play();
    }
}