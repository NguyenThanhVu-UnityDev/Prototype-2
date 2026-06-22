using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private AggressiveAnimal mainAni;

    private void Awake()
    {
        mainAni = GetComponent<AggressiveAnimal>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (mainAni == null) return;
        if (other.GetComponent<PlayerController>() != null)
        {
            mainAni.OnCollidedWithPlayer(other.gameObject);
            gameObject.SetActive(false);
        }
        else if (other.GetComponent<Food>() != null)
        {
            mainAni.OnCollidedWithFood(other.gameObject);
            gameObject.SetActive(false);
        }
    }

}
