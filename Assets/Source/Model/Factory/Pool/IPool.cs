namespace SwipeOrDie.Factory.Pool
{
    public interface IPool<T>
    {
        T Get();
        void Return(T obj);
    }
}