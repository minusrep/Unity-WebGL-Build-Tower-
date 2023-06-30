using UnityEngine;

namespace Gameplay.Environment
{
    [System.Serializable]
    public class EnvironmentSettings
    {
        public CameraMovement cameraMovement => this._cameraMovement;
        [SerializeField] private CameraMovement _cameraMovement;
        public PlatformMovement platformMovement => this._platformMovement;
        [SerializeField] private PlatformMovement _platformMovement;    
    }
}
