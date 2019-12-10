using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody m_RigidBody;
    Vector3 velocity = new Vector3();

    public float m_JumpSpeed = 200f;

    private bool m_CanJump;
    // Start is called before the first frame update
    void Start()
    {
        //m_RigidBody.useGravity = false;
        //m_RigidBody.isKinematic = true;


        //m_RigidBody.velocity 

        m_CanJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = m_RigidBody.velocity;

        if(Input.GetKey(KeyCode.W))
        {
            velocity.z = 1f;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            velocity.z = -1f;
        }
        else
        {
            velocity.z = 0f;
        }

        // transform.Translate(direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_CanJump)
            {
                m_RigidBody.AddForce(0f, m_JumpSpeed, 0f);
                m_CanJump = false;
            }
        }
    }

    private void FixedUpdate()
    {
        /*velocity = m_RigidBody.velocity;
        velocity.x = 1f;*/
        
        m_RigidBody.velocity = velocity; // mèetre par seconde
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_CanJump = true;
        Debug.Log("J'AI TOUCHER AU PLANCHER");
    }
}
