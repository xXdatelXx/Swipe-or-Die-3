using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.View
{
    public class LosePanel : MonoBehaviour, ILosePanel
    {
        public void Show() => 
            gameObject.SetActive(true);
    }
}