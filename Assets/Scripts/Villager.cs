using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Villager : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform player;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (nav != null && nav.isActiveAndEnabled)
        {
            nav.SetDestination(player.position);
        }
    }
}
