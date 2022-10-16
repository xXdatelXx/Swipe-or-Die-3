using UnityEngine;
using System;

public static class Logger
{
    public static void Log(params object[] obj)
    {
        var value = String.Join(" , ", obj);
        if (value.Length == 0)
            value = "log";

        Debug.Log(value);
    }
}
