using Sirenix.Utilities;
using Source.Model.Timer;
using SwipeOrDie.Extension;
using SwipeOrDie.Roots;
using UnityEngine;
using Zenject;

namespace Source
{
    public class PauseRoot : CompositeRoot
    {
        [SerializeField] private IPauseHandler[] _handlers;
        private IPause _pause;
        
        [Inject]
        public void Construct(IPause pause) => 
            _pause = pause.ThrowExceptionIfArgumentNull(nameof(pause));

        public override void Compose() => 
            _handlers.ForEach(i => _pause.Add(i));
    }
}