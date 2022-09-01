using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Tickables : MonoBehaviour, IITickables
{
    private List<ITickable> _tickables = new();

    private void Update()
    {
        Tick();
    }

    public void Run(ITickable tickable)
    {
        if (tickable == null)
            throw new NullReferenceException($"{nameof(tickable)} == null");
        if (_tickables.Has(tickable))
            throw new InvalidOperationException($"{nameof(tickable)} is duplicate");

        _tickables.Add(tickable);
    }

    public void Stop(ITickable tickable)
    {
        _tickables.Remove(tickable);
    }

    private void Tick()
    {
        foreach (var tickable in _tickables.ToList())
            tickable.Tick(Time.deltaTime);
    }
}