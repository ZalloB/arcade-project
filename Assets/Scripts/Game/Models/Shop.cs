using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    public class Shop
    {
        private List<GameObject> _machines;
        private List<GameObject> _decorativeObjects;

        public Shop(List<GameObject> machines, List<GameObject> decorativeObjects)
        {
            _machines = machines;
            _decorativeObjects = decorativeObjects;
        }

        public List<GameObject> Machines
        {
            get => _machines;
            set => _machines = value;
        }

        public List<GameObject> DecorativeObjects
        {
            get => _decorativeObjects;
            set => _decorativeObjects = value;
        }
    }
}