using System;
using System.Collections.Generic;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(menuName = "Complexity", fileName = "Complexity")]
    public class Complexity : ScriptableObject
    {
        [SerializeField] private List<int> _level = new();
        private int _valuesCount;

        private void OnEnable()
        {
            _valuesCount = Enum.GetNames(typeof(Value)).Length;
        }

        private void OnValidate()
        {
            _level.SetCount(_valuesCount);
            _level.SortHerringbone();
        }

        public Value Get(IScore score)
        {
            for (int i = 0; i < _level.Count; i++)
            {
                if (score.Value <= _level[i])
                    return (Value)i;
            }

            return (Value)_valuesCount;
        }

        public enum Value
        {
            First,
            Second,
            Third,
            Fourth
        }
    }
}
