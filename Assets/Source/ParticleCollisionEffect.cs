using SwipeOrDie.Extension;
using UnityEngine;

namespace Source
{
    public sealed class ParticleCollisionEffect : CollisionEffect
    {
        [SerializeField] private ParticleSystem _particle;

        private void Awake() =>
            _particle.ThrowExceptionIfNull(nameof(_particle));

        public override void Enable()
        {
            gameObject.SetActive(true);
            _particle.Play();
        }

        public override void Disable()
        {
            gameObject.SetActive(false);
            _particle.Stop();
        }
    }
}