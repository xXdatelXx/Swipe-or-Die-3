using System.Threading.Tasks;

namespace SwipeOrDie.Model
{
    public interface IDestroyStrategy
    {
        Task Destroy();
    }
}