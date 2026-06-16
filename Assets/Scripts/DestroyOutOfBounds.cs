using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float topBound = 30f;
    [SerializeField] float bottomBound = -10f;
    [SerializeField] float sideBound = 30f;
    void Update()
    {
        // Currently, only food can exceed the top bound
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        // Currently, only the animals can exceed the bottom bound
        if (transform.position.z < bottomBound)
        {
            GameEvents.RainOnMissAnimal();
            Destroy(gameObject);
        }

        if (transform.position.x < -sideBound || transform.position.x > sideBound)
        {
            GameEvents.RainOnMissAnimal();
            Destroy(gameObject);
        }
    }
}
