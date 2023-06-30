using UnityEngine;
using Gameplay.Core;

namespace Gameplay.Player
{
    [System.Serializable]
    public class PlayerSettings
    {
        public Tower tower { get; private set; }
        public PlayerUI ui => this._ui;
        
        [SerializeField] private PlayerUI _ui;

        public void Initialize(GameObject gameObject)
        {
            this.tower = gameObject.GetComponent<Tower>();
        }
    }
}
