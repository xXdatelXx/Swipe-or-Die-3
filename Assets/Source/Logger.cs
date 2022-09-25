using UnityEngine;

public static class Logger
{
    public static void Log()
    {
        Debug.Log("log");
    }

    public static void Log(object obj)
    {
        Debug.Log(obj);
    }

    public static void Log(object a, object b)
    {
        Debug.Log(a + " " + b);
    }

    public static void Log(object a, object b, object c)
    {
        Debug.Log(a + " " + b + " " + c);
    }

    public static void Log(object a, object b, string m)
    {
        Debug.Log(a + " " + m + " " + b);
    }

    public static void Log(object a, string m1, object b, string m2, object c)
    {
        Debug.Log(a + " " + m1 + " " + b + " " + m2 + " " + c);
    }
}
