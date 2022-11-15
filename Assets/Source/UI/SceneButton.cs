using SwipeOrDie.Extension;
using UnityEditor;
using UnityEngine;

public sealed class SceneButton : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;
    
    public void Switch() => 
        _scene.Load();
}
