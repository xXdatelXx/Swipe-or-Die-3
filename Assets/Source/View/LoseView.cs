using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class LoseView : SerializedMonoBehaviour, ILoseView
    {
        [SerializeField] private ITimer _timer;
        [SerializeField] private ILosePanel _losePanel;
        
        public async void OnLose()
        {
            await _timer.Play();
            _losePanel.Show();
        }
    }
}