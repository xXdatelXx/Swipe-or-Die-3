namespace Source.Model.Storage
{
    public interface IStorage<T>
    {
        bool Exists();
        T Load();
        void Save(T value);
    }
}