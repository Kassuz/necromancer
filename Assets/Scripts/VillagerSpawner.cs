using UnityEngine;
using System.Collections;

public class VillagerSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject villagerPrefab;

    private float timeTillNextSpawn;
    private float spawnTimeDelta = 4f;

    void Update()
    {
        if (Time.time > timeTillNextSpawn)
        {
            timeTillNextSpawn = Time.time + spawnTimeDelta;
            Instantiate(villagerPrefab, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
        }
    }
}
