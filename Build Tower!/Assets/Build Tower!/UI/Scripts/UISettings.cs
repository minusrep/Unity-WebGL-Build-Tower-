using System;
using UnityEngine;

namespace Gameplay.UI
{
    [System.Serializable]
    public class UISettings
    {
        public UIWindow startWindow => this._startWindow;
        public UIWindow loseWindow => this._loseWindow;
        public UIWindow hud => this._hud;

        [SerializeField] private UIWindow _startWindow;
        [SerializeField] private UIWindow _loseWindow;
        [SerializeField] private UIWindow _hud;
    }
}
