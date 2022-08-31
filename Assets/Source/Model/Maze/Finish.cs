using System;
using UnityEngine;
using Zenject;

public class Finish : MonoBehaviour
{
    private LevelCreator _levelCreator;

    [Inject]
    public void Init(LevelCreator levelCreator)
    {
        _levelCreator = levelCreator ?? throw new ArgumentNullException($"{nameof(levelCreator)} == null");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<CharacterMovement>() == null)
            return;
        
        _levelCreator.Create();
    }
}
