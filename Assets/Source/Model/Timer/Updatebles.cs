using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Model.Timer
{
    public class Updatebles : MonoBehaviour, IUpdatebles
    {
        private readonly List<IUpdateble> _updatebles = new();

        private void Update()
        {
            _updatebles.ForEach(i => i.Update(Time.deltaTime));
        }

        public void Add(IUpdateble updateble)
        {
            if (updateble is null)
                throw new ArgumentNullException(nameof(updateble));

            _updatebles.Add(updateble);
        }

        public void Remove(IUpdateble updateble)
        {
            if (_updatebles.Contains(updateble) == false)
                throw new InvalidOperationException(nameof(Remove));

            if (updateble is null)
                throw new ArgumentNullException(nameof(updateble));

            _updatebles.Remove(updateble);
        }
    }
}