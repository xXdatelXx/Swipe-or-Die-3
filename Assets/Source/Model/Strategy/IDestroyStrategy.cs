using System.Threading.Tasks;

namespace SwipeOrDie.GameLogic
{
    public interface IDestroyStrategy
    {
        Task Destroy();
    }
}