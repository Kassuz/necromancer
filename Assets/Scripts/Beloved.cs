using UnityEngine;
using System.Collections;

public class Beloved : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("Player touched");
            transform.parent = col.gameObject.transform;
            transform.localPosition = new Vector3(0f, 1f, .5f);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            GetComponent<Collider>().enabled = false;
        }
    }

}
