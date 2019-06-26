using UnityEngine;

namespace Game.Managers
{
    public class ClientManager : MonoBehaviour
    {
        public GameObject clientPrefab;
        [SerializeField]
        private int numberOfInitialClients = 5;
        private GameObject _spawn;

        private void Start()
        {
            _spawn = GameObject.FindGameObjectWithTag("Spawn");

            if (clientPrefab != null)
            {
                GenerateClients(numberOfInitialClients);
            }
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
            for (var i = 0; i < quantity; i++)
            {
                Instantiate(clientPrefab, _spawn.transform.position, Quaternion.identity);
            }
        }
    }
}
