using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gameplay.Player
{
    [System.Serializable]
    public class PlayerUI 
    {
        public int coins
        {
            set
            {
                this.coinsInfo.text = ($"{value}");
            }
        }

        [SerializeField] private TextMeshProUGUI coinsInfo;
    }

}
