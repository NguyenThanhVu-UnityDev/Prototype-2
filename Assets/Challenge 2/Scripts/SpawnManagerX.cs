using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    [SerializeField] float spawnLimitXLeft = -22;
    [SerializeField] float spawnLimitXRight = 7;
    [SerializeField] float spawnPosY = 30;

    [SerializeField] float startDelay = 1.0f;
    [SerializeField] float minSpawnInterval = 3.0f;
    [SerializeField] float maxSpawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("SpawnRandomBall", spawnInterval);
    }

}
