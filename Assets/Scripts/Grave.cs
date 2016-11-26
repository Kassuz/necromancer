using UnityEngine;
using System.Collections;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;

    private bool isEmpty = false;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !isEmpty)
        {
            PlayerMovement pM = col.GetComponent<PlayerMovement>();
            if (pM.IsResurrecting)
            {
                isEmpty = true;
                StartCoroutine(SpawnZombie());                
            }
        }
    }

    private IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
    }

}
