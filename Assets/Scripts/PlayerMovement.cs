using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    public bool IsResurrecting { get; private set; }

    private Rigidbody rb;
    private Animator anim;
    private GameManager gm;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0))
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
        if (inputX != 0 || inputY != 0)
        {
            anim.SetBool("Moving", true);
        } 
        else
        {
            anim.SetBool("Moving", false);
        }

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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Villager")
        {
            gm.GameLost();
            Destroy(gameObject);
        }
    } 

}
