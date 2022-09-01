using UnityEngine;

public interface IMonoBehaviourFactory
{
    T Create<T>(T monoObject) where T : MonoBehaviour;
}
