using UnityEngine;
using System.Collections;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime = .3f;

    private float offsetX = 8f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x + offsetX, transform.position.y, player.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

}
