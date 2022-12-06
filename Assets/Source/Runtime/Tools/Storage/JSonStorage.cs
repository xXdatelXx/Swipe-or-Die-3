using UnityEngine;
using System.IO;
using SwipeOrDie.Extension;
using SystemPath = System.IO.Path;

namespace SwipeOrDie.Storage
{
    public sealed class JSonStorage<T> : IStorage<T>
    {
        private readonly IPath _path;
        
        public JSonStorage(string path) : 
            this(new Path(path)) { }

        public JSonStorage(IPath path) => 
            _path = path.ThrowExceptionIfNull();

        public bool Exists() => File.Exists(_path.Value);

        public T Load() => 
            JsonUtility.FromJson<T>(File.ReadAllText(_path.Value));

        public void Save(T value) => 
            File.WriteAllText(_path.Value, JsonUtility.ToJson(value));
    }
}