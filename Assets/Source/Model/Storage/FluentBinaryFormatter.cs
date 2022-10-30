using System.Runtime.Serialization.Formatters.Binary;
using SwipeOrDie.Extension;

namespace Source.Model.Storage
{
    public class FluentBinaryFormatter<T>
    {
        private readonly IPath _path;
        private readonly BinaryFormatter _formatter;

        public FluentBinaryFormatter(IPath path)
        {
            _path = path.TryThrowNullReferenceException();
            _formatter = new();
        }

        public T Deserialize() => 
            (T)_formatter.Deserialize(_path.OpenFile());

        public void Serialize(T obj) => 
            _formatter.Serialize(_path.OpenFile(), obj);
    }
}