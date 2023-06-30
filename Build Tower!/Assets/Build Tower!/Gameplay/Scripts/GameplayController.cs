using System;
using UnityEngine;
using System.Collections.Generic;
using Gameplay;
using Gameplay.Core;
public class GameplayController
{
    private event Action<GameState> OnGameStateChangeEvent;
    private Dictionary<Type, Controller> controllersMap;

    public GameplayController()
    {
        this.controllersMap = new Dictionary<Type, Controller>();

        var type = typeof(SampleController);
        var sample = new SampleController();
        this.controllersMap[type] = sample;
        type = typeof(PlayerController);
        var data = new PlayerData();
        var player = new PlayerController(data, sample, this.ChangeGameState);
        this.controllersMap[type] = player;
        type = typeof(UIController);
        var ui = new UIController();
        this.controllersMap[type] = ui;
        type = typeof(EnvironmentController);
        var environment = new EnvironmentController(player);
        this.controllersMap[type] = environment;

        this.SubscribeAllControllers();
        this.ChangeGameState(GameState.IsIdle);
    }

    public T GetController<T>() where T : Controller
    {
        controllersMap.TryGetValue(typeof(T), out var founded);
        return (T)founded;
    }

    protected void ChangeGameState(GameState value)
    {
        this.OnGameStateChangeEvent?.Invoke(value);
    }

    private void SubscribeAllControllers()
    {
        foreach(var controller in this.controllersMap.Values)
        {
            this.OnGameStateChangeEvent += controller.OnGameStateChange;
        }
    }
}
