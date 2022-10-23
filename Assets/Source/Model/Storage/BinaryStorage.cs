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
            /*using var file = Exists(GetPath(path)) 
                    ? File.Open(GetPath(path), FileMode.Open) 
                    : throw new InvalidDataException("dont have data from path");
            
            return (T)_formatter.Deserialize(file);*/
            return default;
        }

        public bool Exists(string name)
        {
            return true;
            //return File.Exists(GetPath(name));
        }

        public void Save<T>(string path, T saveObject)
        {
            //using var file = File.Create(GetPath(path));
            //_formatter.Serialize(file, saveObject);
        }

        private string GetPath(string name)
        {
            return Path.Combine(Application.persistentDataPath, name);
        }
    }
}