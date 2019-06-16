using UnityEngine;

public class DespawnBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Client"))
        {
            Destroy(other.gameObject);
        }
    }
}
