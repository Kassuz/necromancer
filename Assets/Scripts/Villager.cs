using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Villager : MonoBehaviour
{
    public float health = 100f;

    private NavMeshAgent nav;
    private Transform player;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (nav != null && nav.isActiveAndEnabled && player != null)
        {
            nav.SetDestination(player.position);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
