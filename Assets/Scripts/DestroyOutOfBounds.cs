using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float topBound = 30;
    [SerializeField] float lowerBound = -10;
    [SerializeField] float rightBound = 30;
    [SerializeField] float leftBound = -30;

    [SerializeField] UnityEvent onDestroy = new();

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound ||
            transform.position.z < lowerBound ||
            transform.position.x > rightBound ||
            transform.position.x < leftBound)
        {
            onDestroy.Invoke();
            gameObject.SetActive(false);

        }
        //else if (transform.position.z < lowerBound)
        //{
        //    Debug.Log("Game Over!");
        //    Destroy(gameObject);
        //}

    }
}
