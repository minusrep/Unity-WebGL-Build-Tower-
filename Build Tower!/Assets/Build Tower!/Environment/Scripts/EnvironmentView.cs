using UnityEngine;
using Gameplay.Core;

namespace Gameplay.Environment
{
    public class EnvironmentView : View<EnvironmentController>
    {
        [SerializeField] private EnvironmentSettings settings;

        protected override void OnControllerSetten()
        {
            this.controller.settings = this.settings;
        }
    }
}
