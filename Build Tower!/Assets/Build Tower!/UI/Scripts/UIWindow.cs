using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI
{
    public class UIWindow : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private void Awake()
        {
            this.animator = this.gameObject.GetComponent<Animator>();
        }
        public void Close()
        {
            this.animator.SetTrigger("Close");
        }

        public void OnDisappearAnimationEnd() => this.gameObject.SetActive(false);
    }
}

