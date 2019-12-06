using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge2PlayerController : MonoBehaviour
{
    public float m_Speed;

    private Rigidbody m_RbPlayer;
    private Vector3 m_NewVelocityPlayer;

    private void Awake()
    {
        m_RbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Deplacement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();

        }
    }

    private void Deplacement()
    {
        m_NewVelocityPlayer = m_RbPlayer.velocity;
        if (Input.GetKey(KeyCode.W))
        {
            m_NewVelocityPlayer.z = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_NewVelocityPlayer.z = -1f;
        }
        else
        {
            m_NewVelocityPlayer.z = 0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_NewVelocityPlayer.x = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_NewVelocityPlayer.x = -1f;
        }
        else
        {
            m_NewVelocityPlayer.x = 0f;
        }
        m_NewVelocityPlayer.Normalize();
        m_NewVelocityPlayer *= m_Speed;

        m_NewVelocityPlayer.y = m_RbPlayer.velocity.y;

        m_RbPlayer.velocity = m_NewVelocityPlayer;
    }
}
