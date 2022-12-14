using System.IO;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Storage
{
    public sealed class BinaryStorage<T> : IStorage<T>
    {
        private readonly FluentBinaryFormatter<T> _formatter;
        private readonly IPath _path;

        public BinaryStorage(string path) : this(new Path(path))
        { }

        public BinaryStorage(IPath path)
        {
            _path = path.ThrowExceptionIfNull();
            _formatter = new(path);
        }

        public bool Exists() => File.Exists(_path.Value);

        public T Load() => 
            _formatter.Deserialize();

        public void Save(T value) => 
            _formatter.Serialize(value);
    }
}