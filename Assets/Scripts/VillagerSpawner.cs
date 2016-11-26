using UnityEngine;
using System.Collections;

public class VillagerSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject villagerPrefab;

    private float timeTillNextSpawn;
    private float spawnTimeDelta = 6f;

    void Update()
    {
        if (Time.time > timeTillNextSpawn)
        {
            timeTillNextSpawn = Time.time + spawnTimeDelta;
            int spawnerNumber = Random.Range(0, spawners.Length);
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                Instantiate(villagerPrefab, spawners[spawnerNumber].position + Vector3.right * i * 3, Quaternion.identity);
            }
            
        }
    }
}
