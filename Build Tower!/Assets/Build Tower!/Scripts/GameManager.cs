using System;
using UnityEngine;
using Gameplay.Core;

public sealed class GameManager : MonoBehaviour
{
    private const string NAME = "GameManager";

    public static event Action OnControllersCreatedEvent;
    public static GameManager instance => GetInstance();
    private static GameManager _instance;

    private GameplayController gameplay;


    private static GameManager GetInstance()
    {
        if (_instance == null) CreateSingelton();
        return _instance;
    }
    private static void CreateSingelton()
    {
        _instance = new GameObject(NAME).AddComponent<GameManager>();
        _instance.Initialize();
        
    }

    private void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        _instance = this;
        _instance.Initialize();
    }

    private void Initialize()
    {
        this.gameplay = new GameplayController();
        OnControllersCreatedEvent?.Invoke();
        Debug.Log("Controllers created");
    }

    public T GetController<T>() where T : Controller => this.gameplay.GetController<T>();
}