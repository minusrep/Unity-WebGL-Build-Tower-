using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Floor : MonoBehaviour
    {
        public float size
        {
            get => this.gameObject.transform.localScale.y;

            set
            {

                if (value < 0f) value = 0f;
                
                var toScale = this.gameObject.transform.localScale;
                toScale.y = value;
                this.gameObject.transform.localScale = toScale;
                if (value > 0f) this.root.SetActive(true);
                else this.root.SetActive(false);

            }
        }

        public Color color
        {
            get => this.meshRenderer.material.color;
            set => this.meshRenderer.material.color = value;
        }

        private GameObject root;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            this.root = this.gameObject.transform.GetChild(0).gameObject;
            this.meshRenderer = this.root.GetComponent<MeshRenderer>();
            this.size = 0f;
            this.color = Random.ColorHSV();
        }


    }
}

