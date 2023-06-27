using System;
using System.Collections.Generic;
using Gameplay;
using Gameplay.Core;
public class GameplayController
{
    private Dictionary<Type, Controller> controllersMap;

    public GameplayController()
    {
        this.controllersMap = new Dictionary<Type, Controller>();
        var type = typeof(PlayerController);
        var data = new PlayerData();
        var player = new PlayerController(data);
        this.controllersMap[type] = player;
    }

    public T GetController<T>() where T : Controller
    {
        controllersMap.TryGetValue(typeof(T), out var founded);
        return (T)founded;
    }
}
