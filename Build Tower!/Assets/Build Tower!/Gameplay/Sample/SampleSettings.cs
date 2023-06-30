using UnityEngine;
using Gameplay.Player;

namespace Gameplay.Sample
{
    [System.Serializable]
    public class SampleSettings : PlayerSettings
    {
        public int advance => this._advance;
        public float minFloorSize => this._minFloorSize;
        public float maxFloorSize => this._maxFloorSize;
        public float errorRate => this._errorRate;

        [SerializeField] private int _advance;
        [SerializeField] private float _minFloorSize;
        [SerializeField] private float _maxFloorSize;
        [SerializeField] private float _errorRate;

    }
}
