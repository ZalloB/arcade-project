using System.Collections.Generic;
using Game.Models;
using UnityEngine;

namespace Game.Managers
{
    public class BuildingSystemManager : MonoBehaviour
    {
        public List<BuildPreviewObject> objects = new List<BuildPreviewObject>();
        public BuildPreviewObject currentObject;
        private Vector3 currentPos;
        public Transform currentPreview;

        public Transform cam;
        public RaycastHit hit;
        public LayerMask layer;

        public float offset = 1.0f;
        public float gridSize = 1.0f;

        public bool IsBuilding;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            
            currentObject = objects[0];
            ChangeCurrentBuilding();
        }

        private void Update()
        {
            if (IsBuilding)
            {
                showPreview();

                if (Input.GetButtonDown("fire1"))
                {
                    Build();
                }
            }
        }


        public void ChangeCurrentBuilding()
        {
            var curPrev = Instantiate(currentObject.preview, currentPos, Quaternion.identity);
            currentPreview = curPrev.transform;
        }


        private void showPreview()
        {
            currentPos =
                _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0.045f, Input.mousePosition.z));
            currentPreview.position = currentPos;
        }

        public void Build()
        {
            var previewObj = currentPreview.GetComponent<PreviewObject>();
            if (previewObj.IsBuildable)
            {
//              TODO: Instantiate(currentFinalObject, currentPos, Quaternion.identity);
            }
        }
    }
}


public class BuildPreviewObject
{
    public string name;
    public GameObject preview;
    public int gold;
}

