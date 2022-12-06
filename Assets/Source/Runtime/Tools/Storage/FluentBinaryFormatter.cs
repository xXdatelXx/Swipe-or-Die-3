using System.Runtime.Serialization.Formatters.Binary;
using SwipeOrDie.Extension;
using System.IO;

namespace SwipeOrDie.Storage
{
    public sealed class FluentBinaryFormatter<T>
    {
        private readonly IPath _path;
        private readonly BinaryFormatter _formatter;

        public FluentBinaryFormatter(IPath path)
        {
            _path = path.ThrowExceptionIfNull();
            _formatter = new();
        }

        public T Deserialize()
        {
            using var file = _path.OpenFile();
            return (T)_formatter.Deserialize(file);
        }

        public void Serialize(T obj)
        {
            using var file = File.Create(_path.Value);
            _formatter.Serialize(file, obj);
        }
    }
}