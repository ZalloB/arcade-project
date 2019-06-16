using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using Game.Models;
using UnityEngine;

namespace Game
{
    public class MachineBehaviour : MonoBehaviour
    {

        public Machine _machine;
        private List<Client> _clients;
        
        private GameLevelManager _gameLevelManager;
        
        private void Start()
        {
            if (_machine == null)
            {
                _machine = new Machine(1200, 900, 20, 5);
            }
            _clients = new List<Client>();
            
            _gameLevelManager = FindObjectOfType<GameLevelManager>().GetComponent<GameLevelManager>();
        }


//        private void Update()
//        {
//         
//        }


        public void getClient(GameObject _gameObjectClient)
        {
            var clientBehaviour = _gameObjectClient.GetComponent<ClientBehaviour>();

            _clients.Add(clientBehaviour.getClient());
            clientBehaviour.playing = true;
            clientBehaviour.restClientMoney(_machine.MoneyGame);
            _machine.Full = true;
            StartCoroutine(nameof(spendClientTime), clientBehaviour);
            _gameLevelManager.makePurchase(_machine.MoneyGame);

            _clients.Remove(clientBehaviour.getClient());
            clientBehaviour.playing = false;
        }

        private IEnumerator spendClientTime(ClientBehaviour clientBehaviour)
        {
            yield return new WaitForSeconds(_machine.SpendTime);
            clientBehaviour.notBusy();
            _machine.Full = false;
        }

        public bool checkFullMachine()
        {
            return _machine.Full != null;
        }
        
        
    }
}