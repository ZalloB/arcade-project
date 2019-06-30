using System.Collections;
using UnityEngine;

namespace Game.Managers
{
    public class ClientManager : MonoBehaviour
    {
        public GameObject clientPrefab;
        [SerializeField]
        private int numberOfInitialClients = 5;
        private GameObject _spawn;

        [SerializeField]
        private int delayTime = 1;
        
        private void Start()
        {
            _spawn = GameObject.FindGameObjectWithTag("Spawn");
        }

        // Update is called once per frame
        private void Update()
        {
            var countClients = GameObject.FindGameObjectsWithTag("Client").Length; 
            if (countClients < numberOfInitialClients/2)
            {
                GenerateClients(numberOfInitialClients);
            }
        }
        


        private void GenerateClients(int quantity)
        {
            StartCoroutine(nameof(InstantiateClients), quantity);
        }

        private IEnumerator InstantiateClients(int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                Instantiate(clientPrefab, _spawn.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(delayTime);
            }
        }
    }
}
