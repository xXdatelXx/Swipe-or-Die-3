using System.Collections.Generic;
using System.Linq;
using SwipeOrDie.Extension;
using SwipeOrDie.GameLogic;
using UnityEngine;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(menuName = "Complexity", fileName = "Complexity")]
    public class Complexity : ScriptableObject
    {
        [SerializeField] private List<int> _level = new();

        private void OnValidate()
        {
            _level.SortHerringbone();
        }

        public int Get(IScore score)
        {
            foreach (int i in _level.Where(i => score.Value <= i))
                return i;

            return _level.Max();
        }
    }
}
