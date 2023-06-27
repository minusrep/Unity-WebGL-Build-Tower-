using System;
using UnityEngine;

namespace Gameplay.Core
{
    public abstract class View<T, S> : MonoBehaviour where T : Controller where S : Settings
    {
        [SerializeField] protected S settings;
        protected T controller;

        private void OnEnable()
        {
            GameManager.OnControllersCreatedEvent += this.OnControllersCreated;
        }

        private void Awake()
        {
            if (this.controller == null) return;
            this.controller.Awake();
        }

        private void Start()
        {
            if (this.controller == null) return;
            this.controller.Start();
        }

        private void Update()
        {
            if (this.controller == null) return;
            this.controller.Update();
        }

        private void FixedUpdate()
        {
            if (this.controller == null) return;
            this.controller.FixedUpdate();
        }

        private void OnDisable()
        {
            GameManager.OnControllersCreatedEvent -= this.OnControllersCreated;
        }

        private void OnControllersCreated()
        {
            this.controller = GameManager.instance.GetController<T>();
            this.controller.SetSettings<S>(this.settings);
        }
    }
}
