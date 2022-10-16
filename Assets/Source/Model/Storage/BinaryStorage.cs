using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Source.Model.Storage
{
    public sealed class BinaryStorage : IStorage
    {
        private readonly BinaryFormatter _formatter = new();

        public T Load<T>(string path)
        {
            var file = File.Open(CreatePath(path), FileMode.Open);
            return (T)_formatter.Deserialize(file);
        }

        public void Save<T>(string path, T saveObject)
        {
            var file = File.Create(CreatePath(path));
            //_formatter.Serialize(file, saveObject);
        }

        public bool Exists(string name)
        {
            return File.Exists(CreatePath(name));
        }

        private string CreatePath(string name)
        {
            return Path.Combine(Application.persistentDataPath, name);
        }
    }
}