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

        [SerializeField]
        private int moneyCost;
        [SerializeField]
        private int sellPrice;
        [SerializeField]
        private int moneyGame;
        [SerializeField]
        private int spendTime;
        
        private GameLevelManager _gameLevelManager;
        
        private void Start()
        {
            if (_machine == null)
            {
                _machine = new Machine(moneyCost, sellPrice, moneyGame, spendTime);
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

            _clients.Add(clientBehaviour.GetClient());
            clientBehaviour.playing = true;
            clientBehaviour.RestClientMoney(_machine.MoneyGame);
            _machine.Full = true;
            StartCoroutine(nameof(spendClientTime), clientBehaviour);
            _gameLevelManager.MakeMachinePurchase(_machine.MoneyGame);

            _clients.Remove(clientBehaviour.GetClient());
            clientBehaviour.playing = false;
        }

        private IEnumerator spendClientTime(ClientBehaviour clientBehaviour)
        {
            yield return new WaitForSeconds(_machine.SpendTime);
            clientBehaviour.NotBusy();
            _machine.Full = false;
        }

        public bool checkFullMachine()
        {
            return _machine.Full != null;
        }

        public int getMoneyCost()
        {
            return moneyCost;
        }
    }
}