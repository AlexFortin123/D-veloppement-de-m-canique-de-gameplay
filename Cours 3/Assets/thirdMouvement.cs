using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdMouvement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float turnSpeed = 10f;
    public float JumpHeight = 0;
    Vector3 newPos;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        newPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {


        newPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            newPos.z = newPos.z + speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newPos.z = newPos.z - speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x = newPos.x - speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPos.x = newPos.x + speed;
        }
        transform.position = newPos;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 10 * JumpHeight * Time.deltaTime, 0);
        }
    }
}