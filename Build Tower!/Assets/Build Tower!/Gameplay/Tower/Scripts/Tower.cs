using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Tower : MonoBehaviour
    {
        //temp
        [SerializeField] private float speed;
        //

        private float size
        {
            get
            {
                var value = 0f;
                foreach (var floor in this.floors) value += floor.size;
                return value;
            }
        }

        private Floor currentFloor;

        private Floor floorPrefab;
        private List<Floor> floors;


        private void Awake()
        {
            this.floors = new List<Floor>();
            this.floorPrefab = Resources.Load<Floor>("Floor");
            this.currentFloor = Instantiate(this.floorPrefab, this.transform);
        }

        public void IncreaseCurrentFloor(float value)
        {
            if (value <= 0f) return;
            this.currentFloor.size += value;
        }

        public void CompleteCurrentFloor()
        {
            this.floors.Add(this.currentFloor);
            var toPosition = this.transform.position;
            toPosition.y += this.size;
            var toRotation = this.transform.rotation;
            var newFloor = Instantiate(this.floorPrefab, toPosition, toRotation, this.transform);
            this.currentFloor = newFloor;
        }


        // temp

        private void Update()
        {

            this.IncreaseCurrentFloor(Time.deltaTime * this.speed);

            if (Input.anyKeyDown) this.CompleteCurrentFloor();
        }


    }

}
