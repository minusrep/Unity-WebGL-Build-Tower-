using UnityEngine;

namespace Gameplay.Environment
{
    [System.Serializable]
    public class CameraMovement
    {
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 offset;
        [SerializeField] [Range(0f, 10f)] private float smoothness;

        public void FollowPlayer(float towerSize)
        {
            var transform = Camera.main.transform;
            var toPosition = this.offset;
            toPosition.y += towerSize;
            transform.position = Vector3.Lerp(transform.position, toPosition, this.smoothness * Time.deltaTime);
        }

        public void ResetPosition()
        {
            Camera.main.transform.position = this.startPosition;
        }
    }
}
