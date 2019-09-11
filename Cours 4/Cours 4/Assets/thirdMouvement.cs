using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdMouvement : MonoBehaviour
{
    public Rigidbody rb;
    //public float speed;
    public float turnSpeed = 10f;
    //public float JumpHeight = 0;
    //Vector3 newPos;
    Vector3 velocity;
    public float jumpSpeed = 200f;
    private bool m_canJump;
    public float x_speed;
    public float z_speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //newPos = new Vector3();
        m_canJump = false;

    }

    // Update is called once per frame
    void Update()
    {

        /*
        //newPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            //newPos.z = newPos.z + speed;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //newPos.z = newPos.z - speed;
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //newPos.x = newPos.x - speed;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //newPos.x = newPos.x + speed;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //transform.position = newPos;*/

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        velocity = transform.InverseTransformDirection(rb.velocity);
        //velocity = rb.velocity;
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z = z_speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.z = -z_speed;
        }
        else
        {
            velocity.z = 0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = x_speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -x_speed;
        }
        else
        {
            velocity.x = 0f;
        }

        if (m_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpSpeed, 0);// addForce donne un coup vers une position
            m_canJump = false;
        }
        rb.velocity = transform.TransformDirection(velocity);
    }
    private void FixedUpdate()
    {
        //rb.velocity = velocity; //velocity m/s
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_canJump = true;
    }
}