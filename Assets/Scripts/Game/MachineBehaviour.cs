using System;
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

        public Transform playingSpot;
        
        private void Start()
        {
            if (_machine == null)
            {
                _machine = new Machine(moneyCost, sellPrice, moneyGame, spendTime);
            }
            _clients = new List<Client>();
            
            _gameLevelManager = FindObjectOfType<GameLevelManager>().GetComponent<GameLevelManager>();
        }


        private void Update()
        {
            Debug.Log("MACHINE : ocupada " + _machine.Full + " precio " + _machine.MoneyCost);
        }

        private IEnumerator SpendClientTime(GameObject gameObjectClient)
        {
            _machine.Full = true;
           
            var clientBehaviour = gameObjectClient.GetComponent<ClientBehaviour>();
            _clients.Add(clientBehaviour.GetClient());

            clientBehaviour.RestClientMoney(_machine.MoneyGame);
            yield return new WaitForSeconds(_machine.SpendTime);
            
            _gameLevelManager.MakeMachinePurchase(_machine.MoneyGame);
            clientBehaviour.NotBusy();
           
            _clients.Remove(clientBehaviour.GetClient());

            clientBehaviour.GoRestArea();
            
            Debug.Log("Machine esta ocupada ?? " + _machine.Full);
            
            _machine.Full = false;

        }


        public bool CheckFullMachine()
        {
            return _machine.Full;
        }

        public int GetMoneyCost()
        {
            return moneyCost;
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag.Equals("Client") && !_machine.Full && !other.gameObject.GetComponent<ClientBehaviour>().isResting)
            {
               Debug.Log("Collision Machine");
               StartCoroutine(nameof(SpendClientTime), other.gameObject);
            }
        }
    }
}