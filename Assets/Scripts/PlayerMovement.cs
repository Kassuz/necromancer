using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    public bool IsResurrecting { get; private set; }

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            IsResurrecting = true;
        } 
        else
        {
            IsResurrecting = false;
        }
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Vertical");
        float inputY = Input.GetAxisRaw("Horizontal");

        Move(-inputX, inputY);

    }

    private void Move(float x, float y)
    {
        if (x != 0 || y != 0)
        {
            Vector3 movement = new Vector3(x, 0f, y);

            movement = movement.normalized * speed * Time.deltaTime;


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

            rb.MovePosition(transform.position + movement);
        }
    }

}
