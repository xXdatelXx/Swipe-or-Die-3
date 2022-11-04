using System.IO;
using SwipeOrDie.Extension;
using SystemPath = System.IO.Path;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace Source.Model.Storage
{
    public sealed class BinaryStorage<T> : IStorage<T>
    {
        private readonly FluentBinaryFormatter<T> _formatter;
        private readonly IPath _path;

        public BinaryStorage(string path) :
            this(new Path(path))
        { }

        public BinaryStorage(IPath path)
        {
            _path = path.TryThrowNullReferenceException();
            _formatter = new(path);
        }

        public bool Exists() => File.Exists(_path.Value);

        public T Load()
        {
            var allPath = _path.Value;

            if (Exists() == false)
                throw new InvalidOperationException(nameof(Load));

            var bf = new BinaryFormatter();
            using var file = File.Open(allPath, FileMode.Open);
            return (T)bf.Deserialize(file);

            //return _formatter.Deserialize();
        }

        public void Save(T value)
        {
            var allPath = _path.Value;
            var bf = new BinaryFormatter();
            using var file = File.Create(allPath);
            bf.Serialize(file, value);

            //_formatter.Serialize(value);
        }
    }
}