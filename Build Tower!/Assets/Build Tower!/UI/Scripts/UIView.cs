using UnityEngine;
using Gameplay.Core;

namespace Gameplay.UI
{
    public class UIView : View<UIController>
    {
        [SerializeField] private UISettings settings;
        protected override void OnControllerSetten()
        {
            this.controller.settings = this.settings;
        }

    }
}
