using SwipeOrDie.Extension;
using UnityEditor;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;
    
    public void Switch() => 
        _scene.Load();
}
