using UnityEngine;
using Gameplay.Core;

namespace Gameplay.Sample
{
    [RequireComponent(typeof(Tower))]
    public class SampleView : View<SampleController>
    {
        [SerializeField] private SampleSettings settings;

        private void Awake()
        {
            this.settings.Initialize(this.gameObject);
        }

        protected override void OnControllerSetten()
        {
            this.controller.settings = this.settings;
        }
    }
}
