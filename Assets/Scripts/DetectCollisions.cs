using UnityEngine;
using UnityEngine.Events;

// This script will be attached to Animal Prefabs
public class DetectCollisions : MonoBehaviour
{
    private AggressiveAnimal mainAnimal;
    private void Awake()
    {
        mainAnimal = GetComponent<AggressiveAnimal>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (mainAnimal == null) return;
        if (other.CompareTag("Player")) mainAnimal.OnCollidedWithPlayer(other.gameObject);
        if (other.CompareTag("Food")) mainAnimal.OnCollidedWithFood(other.gameObject);
    }
}
