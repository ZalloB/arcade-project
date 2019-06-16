using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class PreviewObject : MonoBehaviour
    {
        public bool foundation;
        public List<Collider> col = new List<Collider>();
        public Material green;
        public Material red;
        public bool IsBuildable;

        private void Start()
        {
            IsBuildable = true;
        }

        private void Update()
        {
            //TODO: check with a raycast to the floor, if is a buildable floor to places de preview object and change de color
            
        }
    }
}