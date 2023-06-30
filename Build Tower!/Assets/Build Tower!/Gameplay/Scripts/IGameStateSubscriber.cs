using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Core
{
    public interface IGameStateSubscriber
    {
        public void OnGameStateChange(GameState value);

    }

}
