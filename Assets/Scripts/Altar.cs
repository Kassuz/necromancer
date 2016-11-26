using UnityEngine;
using System.Collections;

public class Altar : MonoBehaviour
{

    private GameManager gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        Transform beloved = null;
        if (col.gameObject.GetComponentInChildren<Beloved>() != null)
        {
            beloved = col.gameObject.GetComponentInChildren<Beloved>().gameObject.transform;
        }
        if (beloved != null && beloved.tag == "Beloved")
        {
            print("Beloved on altar");
            beloved.parent = transform;
            beloved.localPosition = new Vector3(0f, 1f, 0f);
            beloved.localScale = new Vector3(.6f, .5f, .2f);
            beloved.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            gm.GameWon();
        }
    }

}
