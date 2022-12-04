using Sirenix.OdinInspector;
using Source;
using UnityEngine;
using SwipeOrDie.Extension;
using SwipeOrDie.Factory;
using SwipeOrDie.Factory.Pool;
using Factory = SwipeOrDie.Factory.Factory<Source.CollisionEffect>;
using SwipeOrDie.GameLogic;
using SwipeOrDie.GameLogic.Part;
using Zenject;

public sealed class CollisionEffectFactory : SerializedMonoBehaviour
{
    [SerializeField] private IAsyncTimer _returnTimer;
    [SerializeField] private CollisionEffect _effect;
    private ICollisionEffectsParent _parent;
    private IPool<CollisionEffect> _pool;

    [Inject]
    public void Construct(ICollisionEffectsParent parent)
    {
        _parent = parent.ThrowExceptionIfArgumentNull(nameof(parent));
        
        _pool = new Pool<CollisionEffect>(new Factory(_effect,
                new MonoBehaviourFactory<CollisionEffect>(transform, _parent.Transform)), _parent.Objects(_effect));
    }

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.IsNot<IBorder>())
            return;

        var effect = Create(collision.CollisionPoint(transform));
        
        await _returnTimer.Play();
        _pool.Return(effect);
    }
    
    private CollisionEffect Create(Vector3 position)
    {
        var effect = _pool.Get();
        effect.SetPosition(position);

        return effect;
    }
}