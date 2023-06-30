using System.Collections.Generic;
using UnityEngine;
using Gameplay.Sample;
using Gameplay.Core;

namespace Gameplay
{
    public class SampleController : Controller
    {
        public float comparativeFloorSize => this.sizes[this.comparativeIndex];
        public float errorRate { get; private set; }
        public SampleSettings settings
        {
            set
            {
                this.tower = value.tower;
                this.advance = value.advance;
                this.baseAdvance = value.advance;
                this.minFloorSize = value.minFloorSize;
                this.maxFloorSize = value.maxFloorSize;
                this.errorRate = value.errorRate;
                for (int i = 0; i < this.advance; i++)
                    this.sizes.Add(Random.Range(this.minFloorSize, this.maxFloorSize));
                this.isInitialized = true;
            }
        }

        private Tower tower;

        private List<float> sizes;
        private int index;
        private int comparativeIndex;
        private int advance;
        private int baseAdvance;
        private float minFloorSize;
        private float maxFloorSize;

        private GameState gameState;

        public SampleController()
        {
            this.sizes = new List<float>();
            this.index = 0;
            this.comparativeIndex = 0;
        }

        public override void FixedUpdate()
        {
            if (this.gameState != GameState.IsPlaying) return;
            if (this.advance <= this.tower.floorsCount) return;

            if (this.tower.currentFloorSize <= this.sizes[this.index])
                this.tower.IncreaseCurrentFloor();
            else
            {
                this.tower.CompleteCurrentFloor();
                this.index++;
            }
        }

        public void OnInput()
        {
            this.sizes.Add(Random.Range(this.minFloorSize, this.maxFloorSize));
            this.advance++;
            this.comparativeIndex++;
        }


        public void Reset()
        {
            this.advance = this.baseAdvance;
            this.index = 0;
            this.comparativeIndex = 0;
            this.sizes.Clear();
            this.sizes = new List<float>();
            for (int i = 0; i < this.advance; i++)
                this.sizes.Add(Random.Range(this.minFloorSize, this.maxFloorSize));
            this.tower.Reset();
        }

        public override void OnGameStateChange(GameState value)
        {
            this.gameState = value;
        }
    }
}
