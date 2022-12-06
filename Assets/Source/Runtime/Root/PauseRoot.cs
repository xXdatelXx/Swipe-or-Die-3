using Sirenix.Utilities;
using SwipeOrDie.Extension;
using SwipeOrDie.Tools;
using UnityEngine;
using Zenject;

namespace SwipeOrDie.Roots
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