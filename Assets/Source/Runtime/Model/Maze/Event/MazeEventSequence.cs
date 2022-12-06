using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.Model
{
    public sealed class MazeEventSequence : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField] private List<IMazeEvent> _events = new();

        public void OnMazeEnabled() => 
            _events.ForEach(e => e.OnMazeEnabled());
    }
}