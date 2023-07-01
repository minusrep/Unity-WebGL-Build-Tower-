using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    private const string NAME = "Coroutines";

    public static Coroutines instance => GetInstance();

    private static Coroutines _instance;

    private static Coroutines GetInstance()
    {
        if (_instance == null) CreateSingelton();
        return _instance;
    }

    private static void CreateSingelton()
    {
        _instance = new GameObject(NAME).AddComponent<Coroutines>();
    }

    public static void StartRoutine(IEnumerator routine)
    {
        instance.StartCoroutine(routine);
    }

    public static void StopRoutine(IEnumerator routine) 
    {
        instance.StopCoroutine(routine);
    }
}
