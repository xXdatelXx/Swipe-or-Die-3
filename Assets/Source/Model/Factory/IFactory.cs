namespace SwipeOrDie.Factory
{
    public interface IFactory<T>
    {
        T Create(T obj);
    }
}