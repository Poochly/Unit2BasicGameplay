using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    public float minSpawnInterval = 0.0f;
    public float maxSpawnInterval = 4.0f;

    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        // Call SpawnRandomBall() method every spawnInterval seconds
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        // Update spawn interval with a new randomized value
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        CancelInvoke();
        InvokeRepeating("SpawnRandomBall", spawnInterval, spawnInterval);
    }

}
