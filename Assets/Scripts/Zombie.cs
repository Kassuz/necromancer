using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform targetVillager;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (targetVillager == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);
            foreach (var col in colliders)
            {
                if (col.gameObject.tag == "Villager")
                {
                    targetVillager = col.transform;
                    break;
                }
            }

        }

        if (nav != null && nav.isActiveAndEnabled && targetVillager != null)
        {
            nav.SetDestination(targetVillager.position);
        }


    }
}
