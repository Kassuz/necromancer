using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform targetVillager;
    private Rigidbody rb;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rb.velocity = Vector3.zero;


        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);
        Transform closestEnemy = null;
        foreach (var col in colliders)
        {
            if (col.gameObject.tag == "Villager")
            {
                if (closestEnemy == null)
                {
                    closestEnemy = col.gameObject.transform;
                    continue;
                }
                Vector3 distanceCurrent = col.gameObject.transform.position - transform.position;
                Vector3 distanceClosest = closestEnemy.position - transform.position;
                if (distanceCurrent.magnitude < distanceClosest.magnitude)
                {
                    closestEnemy = col.gameObject.transform;
                }
            }
        }
        targetVillager = closestEnemy;

        if (nav != null && nav.isActiveAndEnabled && targetVillager != null)
        {
            nav.SetDestination(targetVillager.position);
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Villager")
        {
            col.gameObject.GetComponent<Villager>().health -= 50f;
        }
    }
}
