using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class PreviewObject : MonoBehaviour
    {
        public Material green;
        public Material red;

        public bool isBuildable;
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            isBuildable = false;
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {

            var layerMask = 1 << 10;
            layerMask = ~layerMask;

            var direction = Vector3.down;
            var start = transform.position;
            start.y += 0.1f;
            
            Debug.DrawRay(start, direction , Color.green);
            
            if (Physics.Raycast(transform.position, direction, out var hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.tag.Equals("Buildable"))
                {
                    isBuildable = true;
                    _meshRenderer.material = green;
                }
                else
                {
                    isBuildable = false;
                    _meshRenderer.material = red;
                }
            }else
            {
                isBuildable = false;
                _meshRenderer.material = red;
            }
        }
    }
}