using SwipeOrDie.GameLogic;
using UnityEngine;

namespace Source.View
{
    public class CharacterDyingView : MonoBehaviour, IDyingView
    {
        public void OnDie() => 
            Time.timeScale = 0;
    }
}