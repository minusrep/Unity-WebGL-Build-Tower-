using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Core;

namespace Gameplay.Player
{
    [RequireComponent(typeof(Tower))]
    public sealed class PlayerView : View<PlayerController>
    {
        [SerializeField] private PlayerSettings settings;
        private void Awake()
        {
            this.settings.Initialize(this.gameObject);
        }

        protected override void OnControllerSetten()
        {
            this.controller.settings = this.settings;
        }

        public void OnInputButton()
        {
            this.controller?.OnInput();
        }

        public void OnStartButton()
        {
            this.controller?.OnStart();
        }

        public void OnRestartButton()
        {
            this.controller?.OnRestart();
        }
    }

}
