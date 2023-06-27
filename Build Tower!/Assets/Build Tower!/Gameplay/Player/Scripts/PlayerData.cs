using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gameplay
{
    [System.Serializable]
    public class PlayerData
    {
        public int record;
        public int coins;

        public PlayerData()
        {
            this.record = 0;
            this.coins = 0;
        }
    }

}
