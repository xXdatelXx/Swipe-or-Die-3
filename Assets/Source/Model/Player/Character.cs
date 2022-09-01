using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    [SerializeField] private IRadius _radius;
    private IInput _input;
    private Position _position;

    [Inject]
    public void Construct(IInput input)
    {
        _input = input;
        _position = new Position(transform, _radius);
    }

    private void Update()
    {

    }
}
