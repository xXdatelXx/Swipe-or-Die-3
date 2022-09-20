using UnityEngine;

namespace SwipeOrDie.GameLogic
{
    public class LoseView : MonoBehaviour, ILoseView
    {
        public void OnLose()
        {
            Debug.Log("lose");   
        }
    }
}