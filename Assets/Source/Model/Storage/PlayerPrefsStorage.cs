using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.Model.Storage
{
    public class PlayerPrefsStorage<T> : IStorage<T>
    {
        private readonly string _key;

        public PlayerPrefsStorage(string key) =>
            _key = key.ThrowExceptionIfNull();

        public bool Exists() => 
            PlayerPrefs.HasKey(_key);

        public T Load() => 
            JsonUtility.FromJson<T>(PlayerPrefs.GetString(_key));

        public void Save(T obj)
        {
            PlayerPrefs.SetString(_key, JsonUtility.ToJson(obj));
            PlayerPrefs.Save();
        }
    }
}