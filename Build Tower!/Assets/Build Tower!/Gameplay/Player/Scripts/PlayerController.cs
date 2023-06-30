using System;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Player;
using Gameplay.Core;

namespace Gameplay
{
    public class PlayerController : Controller
    {
        public PlayerSettings settings
        {
            set
            {
                this.tower = value.tower;
                this.ui = value.ui;
                this.isInitialized = true;
            }
        }
        

        public float towerSize => this.tower.size;


        private PlayerData data;
        private PlayerUI ui;
        private Tower tower;
        private SampleController sample;

        private float allError;
        private GameState gameState;
        private Action<GameState> OnGameStateChangedCallback;
        private int coins
        {
            get => this.data.coins;
            set
            {
                this.data.coins = value;
                this.ui.coins = value;
            }
        }


        public PlayerController(PlayerData data, SampleController sample, Action<GameState> OnGameStateChangedCallback)
        {
            this.data = data;
            this.sample = sample;
            this.allError = 0f;
            this.OnGameStateChangedCallback = OnGameStateChangedCallback;
        }

        public override void Update()
        {
            if (this.gameState != GameState.IsPlaying) return;

            if (this.tower.currentFloorSize >= this.sample.comparativeFloorSize + this.allError + this.sample.errorRate)
            {
                this.OnGameStateChangedCallback(GameState.IsLosed);
            }

            this.tower.IncreaseCurrentFloor();
        }

        public void OnInput()
        {
            var erroRate = this.sample.errorRate;

            var currentSize = this.tower.currentFloorSize;
            var toSize = this.allError + this.sample.comparativeFloorSize;
            var delta = toSize - currentSize;
            this.allError = delta;

            if (Mathf.Abs(delta) <= erroRate)
            {
                this.tower.CompleteCurrentFloor();
                this.sample.OnInput();
                this.coins++;
            }
            else
            {
                this.OnGameStateChangedCallback(GameState.IsLosed);
            }
        }

        public void OnStart()
        {
            this.OnGameStateChangedCallback(GameState.IsPlaying);
        }

        public void OnRestart()
        {
            this.sample.Reset();
            this.Reset();
            this.OnGameStateChangedCallback(GameState.IsIdle);
        }

        private void Reset()
        {
            this.allError = 0f;
            this.tower.Reset();
            this.coins = 0;
        }

        public override void OnGameStateChange(GameState value)
        {
            this.gameState = value;
        }
    }

}
