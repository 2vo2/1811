using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out SpawnPoint spawnPoint))
        {
            transform.position = spawnPoint.transform.position;
        }
    }
}
