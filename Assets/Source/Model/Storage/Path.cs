using SwipeOrDie.Extension;
using System.IO;
using UnityEngine;
using SystemPath = System.IO.Path;

namespace Source.Model.Storage
{
    public class Path : IPath
    {
        public string Value { get; }

        public Path(string value)
        {
            value.TryThrowNullReferenceException();
            
#if UNITY_ANDROID && !UNITY_EDITOR
            _value = SystemPath.Combine(Application.persistentDataPath, value);
#else
            Value =  SystemPath.Combine(Application.dataPath, value);
#endif
        }

        public FileStream OpenFile() => 
            File.Open(Value, FileMode.Open);
    }
}