using System;
using System.Collections.Generic;
using Game.Models;
using UnityEngine;

namespace Game.Managers
{
    public class BuildingSystemManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> previewObjects = new List<GameObject>();
        
        [SerializeField]
        private List<GameObject> objects = new List<GameObject>();
        
        private Vector3 _currentPos;
        private Quaternion _currentRotation;
        
        public GameObject currentPreview;

        private int _selectObjectIndex;
        
        public bool isBuilding;

        public bool isSelling;
        
        private Camera _camera;

        private GameLevelManager _gameLevelManager;

        private void Start()
        {
            _camera = Camera.main;
            _gameLevelManager = GetComponent<GameLevelManager>();
//            currentObject = previewObjects[0];
//            ChangeCurrentBuilding();
        }

        private void Update()
        {
            if (isBuilding)
            {
                ShowPreview();

                if (Input.GetButtonDown("Fire2"))
                {
                    rotatePreviewObject();
                }
                
                if (Input.GetButtonDown("Fire1"))
                {
                    InteractWithFloor();
                }
            }
        }

        private void rotatePreviewObject()
        {
            currentPreview.transform.Rotate(0, 90, 0);
            _currentRotation = currentPreview.transform.rotation;
        }

        private void InteractWithFloor()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hit))
            {
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    Build();
                }
            }
        }


        private void ChangePreviewBuilding(GameObject gameObjectPrev)
        {
            if (currentPreview != null)
            {
                Destroy(currentPreview.gameObject);
            }
            currentPreview = Instantiate(gameObjectPrev, _currentPos, Quaternion.identity);
        }


        private void ShowPreview()
        {
            var temp = Input.mousePosition;
            temp.z = 3f; // Set this to be the distance you want the object to be placed in front of the camera.

            var pos = _camera.ScreenToWorldPoint(temp);
            pos.y = 0.05f;
            currentPreview.transform.position = pos;
            _currentPos = pos;
        } 

        private void Build()
        {
            var futureObject = objects[_selectObjectIndex];
            
            var machineBehaviour = futureObject.GetComponentInChildren<MachineBehaviour>();
            var money = machineBehaviour.GetMoneyCost();
            
            if (!currentPreview.GetComponentInChildren<PreviewObject>().isBuildable || !_gameLevelManager.checkPlayerPurchase(money)) return;
            Destroy(currentPreview.gameObject);
            var instantiateObject = Instantiate(futureObject, _currentPos,_currentRotation);
            
            _gameLevelManager.MakePurchase(money);

            if (instantiateObject.tag.Equals("Machine"))
            {
                _gameLevelManager.defaultShop.Machines.Add(instantiateObject);
            }
            isBuilding = false;
        }

        public void OnBuildMode(int indexObject)
        {

            _selectObjectIndex = indexObject;
            isBuilding = true;
            ChangePreviewBuilding(previewObjects[indexObject]);
            _currentRotation = currentPreview.transform.rotation;
            
        }
    }
}



