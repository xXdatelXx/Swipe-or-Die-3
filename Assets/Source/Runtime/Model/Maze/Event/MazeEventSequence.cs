using System.Collections.Generic;
using FluentValidation;
using UnityEngine;
using System;

namespace SwipeOrDie.Model
{
    [Serializable]
    public sealed class MazeEventSequence : IMazeEvent
    {
        [SerializeField] private List<IMazeEvent> _events;

        public void OnMazeEnabled() => 
            _events.ForEach(e => e.OnMazeEnabled());

        public void Init(Maze maze) => _events.ForEach(i => i.Init(maze));

        private class Validator : AbstractValidator<MazeEventSequence>
        {
            public Validator() => 
                RuleForEach(sequence => sequence._events).NotNull();
        }
    }
}