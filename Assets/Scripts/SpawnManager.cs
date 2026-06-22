using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    [SerializeField] float startDelay = 2f;
    [SerializeField] float spawnInterval = 1.5f;

    [Header("Spawn Vertically")]
    [SerializeField] float spawnPositionXRange = 20f;
    [SerializeField] float spawnPositionZ = 20f;

    [Header("Spawn Horizontally")]
    [SerializeField] float spawnPositionZMax = 30f;
    [SerializeField] float spawnPositionZMin = 0f;
    [SerializeField] float spawnPositionXLeft = -20f;
    [SerializeField] float spawnPositionXRight = 20f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        SpawnUpDown();
        SpawnLeftRight();
        SpawnRightLeft();
    }

    private void SpawnUpDown()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Debug.Log($"Index: {animalIndex} Length: {animalPrefabs.Length}");
        Vector3 spawnPos = new(Random.Range(-spawnPositionXRange, spawnPositionXRange), 0, spawnPositionZ);
        var newAnimal = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        newAnimal.transform.rotation = Quaternion.LookRotation(Vector3.back);
    }

    private void SpawnLeftRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(spawnPositionXLeft, 0, Random.Range(spawnPositionZMin, spawnPositionZMax));
        var newAnimal = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        newAnimal.transform.rotation = Quaternion.LookRotation(Vector3.right);
    }

    private void SpawnRightLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(spawnPositionXRight, 0, Random.Range(spawnPositionZMin, spawnPositionZMax));
        var newAnimal = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        newAnimal.transform.rotation = Quaternion.LookRotation(Vector3.left);
    }
}
