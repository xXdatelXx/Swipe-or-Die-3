using System.IO;
using SwipeOrDie.Extension;
using SystemPath = System.IO.Path;

namespace Source.Model.Storage
{
    public sealed class BinaryStorage<T> : IStorage<T>
    {
        private readonly FluentBinaryFormatter<T> _formatter;
        private readonly IPath _path;

        public BinaryStorage(string path) : 
            this(new Path(path)) { }

        public BinaryStorage(IPath path)
        {
            _path = path.TryThrowNullReferenceException();
            _formatter = new(path);
        }

        public bool Exists() => File.Exists(_path.Value);

        public T Load() => 
            _formatter.Deserialize();

        public void Save(T saveObject) =>
            _formatter.Serialize(saveObject);
    }
}