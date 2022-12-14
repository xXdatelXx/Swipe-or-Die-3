namespace SwipeOrDie.Factory
{
    public interface IPool<T> where T : IPoolObject
    {
        T Get();
        void Return(T obj);
    }
}