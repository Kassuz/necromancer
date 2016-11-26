using UnityEngine;
using System.Collections;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject belovedPrefab;

    private GameManager gm;

    private bool isEmpty = false;
    private float timer = 0f;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (timer >= 1f)
        {
            if (gm.ZombiesSpawned >= 20 && !gm.SpawnedBeloved)
            {
                SpawnBeloved();
                gm.SpawnedBeloved = true;
            }
            else if (gm.ZombiesSpawned >= 7 && !gm.SpawnedBeloved)
            {
                if (Random.value <= .30f)
                {
                    SpawnBeloved();
                    gm.SpawnedBeloved = true;
                }
                else
                {
                    SpawnZombie();
                }
                    
            }
            else
            {
                SpawnZombie();
            }
            
            timer = 0;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !isEmpty)
        {
            PlayerMovement pM = col.GetComponent<PlayerMovement>();
            if (pM.IsResurrecting)
            {
                timer += Time.deltaTime;               
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && !isEmpty)
        {
            timer = 0f;
        }
    }

    private void SpawnZombie()
    {
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        gm.ZombiesSpawned++;
    }

    private void SpawnBeloved()
    {
        Instantiate(belovedPrefab, transform.position, belovedPrefab.transform.rotation);
    }
}
