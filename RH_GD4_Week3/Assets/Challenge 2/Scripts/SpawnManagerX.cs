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
    private float spawnIntervalMax = 5.0f;
    private float spawnIntervalMin = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        float interval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        InvokeRepeating("SpawnRandomBall", startDelay, interval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int ball = Random.Range(0, 3);
        Instantiate(ballPrefabs[ball], spawnPos, ballPrefabs[ball].transform.rotation);
    }

}
