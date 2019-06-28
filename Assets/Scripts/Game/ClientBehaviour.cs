using System.Collections.Generic;
using System.Linq;
using Game.Managers;
using Game.Models;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Game
{
    public class ClientBehaviour : MonoBehaviour
    {
        private Client _client;
        private NavMeshAgent _navMeshAgent;
        private GameLevelManager _gameLevelManager;

        public bool isResting;
        public List<GameObject> restAreas;

        private void Awake()
        {
            restAreas = new List<GameObject>();
            //because we dont have models for the clients 
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        private void Start()
        {
            if (_client == null)
            {
                _client = new Client();
            }

            isResting = false;

            restAreas = GameObject.FindGameObjectsWithTag("StayArea").ToList();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _gameLevelManager = FindObjectOfType<GameLevelManager>().GetComponent<GameLevelManager>();
        }


        private void Update()
        {
            Debug.Log("Client money: " + _client.Money);
            if (!isResting)
            {
                FillActualNeeds();
            }
            else
            {
                if (!_navMeshAgent.pathPending)
                {
                    isResting = false;
                }
            }
        }

        private void FillActualNeeds()
        {
            var machine = GetFreeMachine();

            if (_client.Money > 0 && !_navMeshAgent.pathPending && !_client.Busy)
            {
                if (machine != null &&
                    Vector3.Distance(transform.position, machine.gameObject.transform.position) > 0.8)
                {
                    _navMeshAgent.destination = machine.GetComponentInChildren<MachineBehaviour>().playingSpot.position;
                    IsBusy();
                }
            }
            else if (_client.Money <= 0 && !_navMeshAgent.pathPending)
            {
                _navMeshAgent.destination = GameObject.FindGameObjectWithTag("Despawn").transform.position;
            }
        }

        private GameObject GetFreeMachine()
        {
            var auxList = _gameLevelManager.getShopMachines().OrderBy(i => Random.value).ToList();

            return auxList.FirstOrDefault
            (m => !m.GetComponentInChildren<MachineBehaviour>()._machine.Full &&
                  m.GetComponentInChildren<MachineBehaviour>()._machine.MoneyGame <= _client.Money);
        }

        public Client GetClient()
        {
            return _client;
        }

        public void IsBusy()
        {
            _client.Busy = true;
        }

        public void NotBusy()
        {
            _client.Busy = false;
        }

        public void RestClientMoney(double cost)
        {
            _client.Money -= cost;
        }

        public void GoRestArea()
        {
            isResting = true;
            var index = Random.Range(0, restAreas.Count);
            _navMeshAgent.destination = restAreas[index].transform.position;
        }
    }
}