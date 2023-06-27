using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Player;
using Gameplay.Core;

namespace Gameplay
{
    public class PlayerController : Controller
    {

        private PlayerData data;
        public PlayerController(PlayerData data)
        {
            this.data = data;
        }

        public override void SetSettings<T>(T value)
        {
            Debug.Log("Settings");
        }
    }

}
