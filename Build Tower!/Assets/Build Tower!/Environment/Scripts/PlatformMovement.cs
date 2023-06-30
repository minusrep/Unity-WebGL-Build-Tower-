using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment
{
    [System.Serializable]
    public class PlatformMovement 
    {
        [SerializeField] private float minAngle;
        [SerializeField] private float maxAngle;
        [SerializeField] private GameObject platform;
        [SerializeField] private float rotationSpeed;

        private int direction = 1;


        public void ApplyRotation()
        {
            var rotation = this.platform.transform.rotation;
            this.platform.transform.Rotate(Vector3.up, this.rotationSpeed * Time.deltaTime * this.direction);

            if (rotation.eulerAngles.y >= this.maxAngle) this.direction = -1;
            else if (rotation.eulerAngles.y <= this.minAngle) this.direction = 1;

        }
    }

}
