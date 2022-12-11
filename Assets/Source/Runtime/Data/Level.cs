using System.Collections.Generic;
using SwipeOrDie.Extension;
using SwipeOrDie.Model;
using UnityEngine;

namespace SwipeOrDie.Data
{
    [CreateAssetMenu(fileName = nameof(Level))]
    public sealed class Level : ScriptableObject, ILevel
    {
        [SerializeField] private List<int> _level = new();
        private IScore _score;

        public void Init(IScore score) => 
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));

        private void OnValidate() => 
            _level.SortHerringbone();

        public int Get()
        {
            for (int i = 0; i < _level.Count; i++)
            {
                if (_score.Value <= _level[i])
                    return i;
            }

            return _level.Max();
        }
    }
}
