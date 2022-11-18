using Sirenix.OdinInspector;
using UnityEngine;
using SwipeOrDie.Extension;
using SwipeOrDie.Factory.Pool;
using SwipeOrDie.GameLogic;
using SwipeOrDie.GameLogic.Part;

public sealed class CollisionEffect : SerializedMonoBehaviour
{
    [SerializeField] private IAsyncTimer _timer;
    private IPool<CollisionEffectObject> _pool;

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.IsNot<IBorder>()) 
            return;
                
        var effect = _pool.Get();
        effect.Position = collision.CollisionPoint(transform);
        effect.Enable();
        
        
        await _timer.Play();
        _pool.Return(effect);
    }

    private sealed class CollisionEffectObject
    {
        public Vector3 Position;

        public void Enable()
        {
            
        }
    }
}
