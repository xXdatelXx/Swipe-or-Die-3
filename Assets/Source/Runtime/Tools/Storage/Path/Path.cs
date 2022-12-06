using SwipeOrDie.Extension;
using System.IO;
using UnityEngine;
using SystemPath = System.IO.Path;

namespace SwipeOrDie.Storage
{
    public sealed class Path : IPath
    {
        public string Value { get; }

        public Path(string value)
        {
            value.ThrowExceptionIfNull();
        
#if UNITY_ANDROID && !UNITY_EDITOR
            Value = SystemPath.Combine(Application.persistentDataPath, value);
#else
            Value = SystemPath.Combine(Application.dataPath, value);
#endif
        }

        public Stream OpenFile() => 
            File.Open(Value, FileMode.Open);
    }
}