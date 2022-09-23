using System.Collections.Generic;
using System.Linq;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(fileName = nameof(Complexity))]
    public class Complexity : ScriptableObject, IComplexity
    {
        [SerializeField] private List<int> _level = new();

        private void OnValidate()
        {
            _level.SortHerringbone();
        }

        public int Get(IScore score)
        {
            for (int i = 0; i < _level.Count; i++)
            {
                if (score.Value <= _level[i])
                    return i;
            }

            return _level.Max();
        }
    }
}
