using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using SystemPath = System.IO.Path;

namespace Source.Model.Storage
{
    public sealed class BinaryStorage<T> : IStorage<T>
    {
        private readonly BinaryFormatter _formatter;
        private readonly string _path;

        public BinaryStorage(string path)
        {
            _formatter = new();
            _path = SystemPath.Combine(Application.persistentDataPath, path);
        }

        public T Load()
        {
            return Exists()
                ? (T)_formatter.Deserialize(File.Open(_path, FileMode.Open))
                : throw new InvalidDataException("dont have data from path");
        }

        public bool Exists() => File.Exists(_path);

        public void Save(T saveObject) =>
            _formatter.Serialize(File.Create(_path), saveObject);
    }
}