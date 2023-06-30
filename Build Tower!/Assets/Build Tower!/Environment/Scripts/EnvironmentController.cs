using System.Collections;
using System.Collections.Generic;
using Gameplay.Environment;
using Gameplay.Core;

namespace Gameplay
{
    public class EnvironmentController : Controller
    {
        public EnvironmentSettings settings
        {
            set
            {
                this.cameraMovement = value.cameraMovement;
                this.platformMovement = value.platformMovement;
                this.isInitialized = true;
            }
        }

        private CameraMovement cameraMovement;
        private PlatformMovement platformMovement;
        private PlayerController player;
        private GameState gameState;

        public EnvironmentController(PlayerController player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (this.gameState == GameState.IsPlaying)
            {
                this.cameraMovement.FollowPlayer(this.player.towerSize);
                this.platformMovement.ApplyRotation();
            }
        }

        public override void OnGameStateChange(GameState value)
        {
            this.gameState = value;
            if (!this.isInitialized) return;

            switch (value)
            {
                case GameState.IsIdle:
                    this.cameraMovement.ResetPosition();
                    break;
                case GameState.IsPlaying:
                    break;
                case GameState.IsLosed:
                    break;
            }
        }
    }

}
