namespace Source.Model.Storage
{
    public interface IStorage<T>
    {
        public T Load();

        public void Save(T saveObject);

        public bool Exists();
    }
}