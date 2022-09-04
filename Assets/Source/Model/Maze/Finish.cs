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
        if (IsPlayer(collision))
            _levelCreator.Create();
    }

    private bool IsPlayer(Collision collision)
    {
        return collision.collider.GetComponent<Character>() != null;
    }
}
