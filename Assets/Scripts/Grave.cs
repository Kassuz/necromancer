using UnityEngine;
using System.Collections;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;

    private MeshRenderer meshRenderer;

    private bool isEmpty = false;
    private float timer = 0f;

    void Update()
    {
        if (timer >= 1f)
        {
            SpawnZombie();
            timer = 0;
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
    }

}
