using System.Collections;
using UnityEngine;

namespace Gameplay.Environment
{
    [System.Serializable]
    public class CameraMovement
    {
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 offset;
        [SerializeField] [Range(0f, 10f)] private float smoothness;
        [SerializeField] private float scaleSpeed;

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

        public void ScaleSize(float value)
        {
            Camera.main.orthographicSize = value;
        }
        

        private IEnumerator ScaleRoutine(float toScale)
        {
            var currentSize = Camera.main.orthographicSize;
            var direction = 0f;
            if (currentSize <= toScale)
            {

                while (currentSize < toScale)
                {
                    Camera.main.orthographicSize += Time.deltaTime * this.scaleSpeed;
                    yield return null;
                }
            }
            else
            {

                while (currentSize >= toScale)
                {
                    Camera.main.orthographicSize -= Time.deltaTime * this.scaleSpeed;
                    yield return null;
                }
            }



        }

    }
}
