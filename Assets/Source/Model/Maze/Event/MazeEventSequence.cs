using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class MazeEventSequence : SerializedMonoBehaviour, IMazeEvent
    {
        [SerializeField] private List<IMazeEvent> _events;

        public void OnMazeEnabled() => 
            _events.ForEach(e => e.OnMazeEnabled());
    }
}