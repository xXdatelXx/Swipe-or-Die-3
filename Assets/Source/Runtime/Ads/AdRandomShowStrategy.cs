using System;
using SwipeOrDie.Extension;
using UnityEngine;
using Random = System.Random;

namespace SwipeOrDie.Ads
{
    [Serializable]
    public sealed class AdRandomShowStrategy : IAdShowStrategy
    {
        [SerializeField] private readonly int _chance;
        private Random _random;

        public AdRandomShowStrategy(int chance) => 
            _chance = chance.ThrowExceptionIfValueSubZero(nameof(chance));

        public bool CanShow()
        {
            _random ??= new();
            return _random.Percent() < _chance;
        }
    }
}