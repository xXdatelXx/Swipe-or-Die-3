using System;
using System.Collections.Generic;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.Model.Timer
{
    public sealed class Updatebles : MonoBehaviour, IUpdatebles
    {
        private readonly List<IUpdateble> _updatebles = new();

        private void Update() => 
            _updatebles.ForEach(i => i?.Update(Time.deltaTime));

        public void Add(IUpdateble updateble) => 
            _updatebles.Add(updateble.ThrowExceptionIfArgumentNull(nameof(updateble)));

        public void Remove(IUpdateble updateble)
        {
            if (_updatebles.Contains(updateble) == false)
                throw new InvalidOperationException(nameof(Remove));

            _updatebles.Remove(updateble.ThrowExceptionIfArgumentNull(nameof(updateble)));
        }
    }
}