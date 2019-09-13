using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))] // kräv att det finns en GameManager på samma object
public class JumperSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject jumperPrefab;
    float lastSpawnTime;
    [Range(0, 5)]
    public float spawnDelay = 0.000f;
    [Range(0, 2)]
    public float deltaRandomSpawn = 0.1f;


    public float randomSpawnDelay = 6;


    private void Start()
    {
        if (jumperPrefab == null)
            return;


        randomSpawnDelay = spawnDelay;
        SpawnJumper();
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }

    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
        GameObject jumper = Instantiate(jumperPrefab);



	}
}
