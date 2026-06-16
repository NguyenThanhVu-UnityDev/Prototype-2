using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction fireAction;
    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float maxZ = 7f;
    [SerializeField] float minZ = -1f;

    [SerializeField] GameObject projectilePrefab;

    private Vector2 movementInput;
    private void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();

        transform.Translate((Vector3.right * movementInput.x + Vector3.forward * movementInput.y).normalized * speed * Time.deltaTime);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
        else if (transform.position.z > maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }

        if (fireAction.triggered)
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        if (projectilePrefab == null) return;
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
