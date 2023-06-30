using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Core;
using Gameplay.UI;

namespace Gameplay
{
    public class UIController : Controller
    {
        public UISettings settings
        {
            set
            {
                this.startWindow = value.startWindow;
                this.loseWindow = value.loseWindow;
                this.hud = value.hud;
                this.isInitialized = true;
            }
        }

        private UIWindow startWindow;
        private UIWindow loseWindow;
        private UIWindow hud;

        public override void OnGameStateChange(GameState value)
        {
            if (!this.isInitialized) return;

            switch (value)
            {
                case GameState.IsIdle:
                    this.startWindow.gameObject.SetActive(true);
                    this.loseWindow.Close();
                    this.hud.Close();
                    break;
                case GameState.IsPlaying:
                    this.startWindow.Close();
                    this.loseWindow.Close();
                    this.hud.gameObject.SetActive(true);
                    break;
                case GameState.IsLosed:
                    this.startWindow.Close();
                    this.loseWindow.gameObject.SetActive(true);
                    this.hud.Close();
                    break;
            }
        }
    }

}
