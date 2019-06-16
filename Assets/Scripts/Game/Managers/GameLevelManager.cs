using System;
using System.Collections.Generic;
using System.Linq;
using Game.Models;
using Game.UI;
using UnityEngine;

namespace Game.Managers
{
    public class GameLevelManager : MonoBehaviour
    {

        private Player _player;
        public  Shop _defaultShop; 
        private double _startMoney = 10000; // more or less for adjust the difficulty
        private double _costLocalRent = 400;
        private string _playerName = "Arcade Project";
        private UiPlayerGameManager _uiPlayerGameManager;
        public List<GameObject> shopMachines = new List<GameObject>();
        public List<GameObject> shopDecorativeObjects = new List<GameObject>();

    
        private void OnEnable()
        {
            CalendarGameManager.OnMonthPass += managePlayerMoney;
        }


        private void OnDisable()
        {
            CalendarGameManager.OnMonthPass -= managePlayerMoney;
        }
        
        private void Start()
        {
            if (_player == null)
            {
                _defaultShop = new Shop(shopMachines, shopDecorativeObjects);
                _player = new Player(_playerName, _startMoney, _defaultShop);
            }

            if (_uiPlayerGameManager == null)
            {
                _uiPlayerGameManager = GameObject.FindGameObjectWithTag("uiManager").GetComponent<UiPlayerGameManager>();
            }
            _uiPlayerGameManager.SetNameCompany(_player.CompanyName);
        }

        // Update is called once per frame
        private void Update()
        {
            UpdatePlayerData();
        }

        private void UpdatePlayerData()
        {
            _uiPlayerGameManager.UpdateMoney(_player.Money, _player.Currency);
        }


        private void managePlayerMoney()
        {
            // once a month manage the money of the player
            Debug.Log("Remove money: rental");
            _player.Money -= _costLocalRent;
        }

        public void makePurchase(double money)
        {
            Debug.Log("Add money: purchase");
            _player.Money += money;
        }
    }
}
