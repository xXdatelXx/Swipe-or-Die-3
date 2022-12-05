namespace SwipeOrDie.Factory
{
    public interface IGenericFactory<T>
    {
        T Create(T obj);
    }
}