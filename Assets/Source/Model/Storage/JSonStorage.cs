using UnityEngine;
using System.IO;
using SystemPath = System.IO.Path;

namespace Source.Model.Storage
{
    public class JSonStorage<T> : IStorage<T>
    {
        private readonly string _path;

        public JSonStorage(string path) => 
            _path = SystemPath.Combine(Application.persistentDataPath, path);

        public bool Exists() => 
            File.Exists(_path);

        public T Load()
        {
            return Exists() 
                ? JsonUtility.FromJson<T>(File.ReadAllText(_path))
                : throw new InvalidDataException("dont have data from path");
        }

        public void Save(T saveObject) => 
            File.WriteAllText(_path, JsonUtility.ToJson(saveObject));
    }
}