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
        public bool playing;

        private void Awake()
        {
            //because we dont have models for the clients 
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        private void Start()
        {

            if (_client == null)
            {
                _client = new Client();
            }
            
            Debug.Log("Client: " + _client.Money);
            playing = false;
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _gameLevelManager = FindObjectOfType<GameLevelManager>().GetComponent<GameLevelManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            FillActualNeeds();
        }

        private void FillActualNeeds()
        {
            var machine = _gameLevelManager.shopMachines.FirstOrDefault
            (m => !m.GetComponent<MachineBehaviour>()._machine.Full && 
                  m.GetComponent<MachineBehaviour>()._machine.MoneyGame <= _client.Money); 
            
            if ( _client.Money > 0 && !_client.Busy)
            {
                if (machine != null && Vector3.Distance(transform.position, machine.gameObject.transform.position) > 1)
                {
                    _navMeshAgent.destination = machine.gameObject.transform.position;
                    isBusy();
                }
            }else if ((_client.Money <= 0 || machine == null ) && !_client.Busy)
            {
                _navMeshAgent.destination = GameObject.FindGameObjectWithTag("Despawn").transform.position;
            }
        }

        public Client getClient()
        {
            return _client;
        }

        public void isBusy()
        {
            _client.Busy = true;
        }
        
        public void notBusy()
        {
            _client.Busy = false;
        }

        public void restClientMoney(double cost)
        {
            _client.Money -= cost;
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag.Equals("Machine") && !playing)
            {
                Debug.Log("Collision Machine");
               _gameLevelManager.shopMachines.Find(m => other.gameObject).GetComponent<MachineBehaviour>().getClient(gameObject);
            }
        }
    }
}
