using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Tower : MonoBehaviour
    {
        public int floorsCount => this.floors.Count;

        public float currentFloorSize => this.currentFloor.size;


        public float size
        {
            get
            {
                var value = 0f;
                foreach (var floor in this.floors) value += floor.size;
                return value;
            }
        }

        [SerializeField] private float growthRate;
        [SerializeField] private byte gradientStep;
        [SerializeField] private int fxPoolCapacity;

        private Animator onBuildFX;
        private List<Animator> fxPool;
        private int fxPoolIndex;
        private Floor currentFloor;
        private Floor floorPrefab;
        private List<Floor> floors;

        private Color32 gradientColor;

        private void Awake()
        {
            this.floorPrefab = Resources.Load<Floor>("Floor");
            this.onBuildFX = Resources.Load<Animator>("OnBuildFX");
            this.fxPool = new List<Animator>();
            for (int i = 0; i < this.fxPoolCapacity; i++) this.fxPool.Add(Instantiate(this.onBuildFX, this.transform));
            this.fxPoolIndex = 0;
            this.Reset();
        }

        public void IncreaseCurrentFloor()
        {
            this.currentFloor.size += this.growthRate * Time.deltaTime;
        }

        public void CompleteCurrentFloor()
        {
            var rgb = (byte)(this.gradientColor.r + this.gradientStep);
            if (rgb >= 255) rgb = 55;
            this.gradientColor = new Color32(rgb, rgb, rgb, 255);

            this.floors.Add(this.currentFloor);
            var toPosition = this.transform.position;
            toPosition.y += this.size;
            var toRotation = this.transform.rotation;
            var newFloor = Instantiate(this.floorPrefab, toPosition, toRotation, this.transform);
            this.currentFloor = newFloor;
            this.currentFloor.color = this.gradientColor;
        }

        public void Reset()
        {
            if (this.floors == null) this.floors = new List<Floor>();
            else
            {
                this.floors.Add(this.currentFloor);
                foreach (var floor in this.floors)
                    Destroy(floor.gameObject);
                this.floors.Clear();
                this.floors = new List<Floor>();
            }

            this.gradientColor = new Color32(55, 55, 55, 55);
            this.currentFloor = Instantiate(this.floorPrefab, this.transform);
            this.currentFloor.color = this.gradientColor;
        }

        public void InvokeOnBuildedFX(int id) 
        {
            var fx = this.fxPool[this.fxPoolIndex];
            this.fxPoolIndex++;
            if (this.fxPoolIndex == this.fxPoolCapacity) this.fxPoolIndex = 0;
            var position = this.transform.position;
            position.y += this.size + this.currentFloorSize;
            fx.transform.position = position;
            fx.SetTrigger($"Index {id}");
        }
    }

}
