using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 8f;
    public float g = 24f;
    Vector3 velocity;

    public Transform groundcheck;
    public float groundDistance = 0.1f;
    public float jumpheight = 1f;
    public LayerMask groundmask;
    bool isgrounded;

    void Start()
    {
        transform.position = new Vector3(1.44f, 1.08f, 6.9f);
    }

    // Update is called once per frame
    void Update()
    {   

        isgrounded = Physics.CheckSphere(groundcheck.position, groundDistance,groundmask);
        if (isgrounded && velocity.y<0)
        {
            velocity.y = -1; 
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")&& isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight*2*g );
        }
        velocity.y -= g* Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
