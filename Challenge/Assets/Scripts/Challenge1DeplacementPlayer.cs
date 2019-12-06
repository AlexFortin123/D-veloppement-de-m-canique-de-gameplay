using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge1DeplacementPlayer : MonoBehaviour
{
    public float m_Speed;

    private Rigidbody m_RbPlayer;
    private Vector3 m_NewVelocityPlayer;
    private Renderer m_Renderer;

    private void Awake()
    {
        m_RbPlayer = GetComponent<Rigidbody>();
        m_Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Deplacement();

        ChangeColor();
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

       // m_NewVelocityPlayer.y = m_RbPlayer.velocity.y;

        m_RbPlayer.velocity = m_NewVelocityPlayer;
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Renderer.material.color = Random.ColorHSV();
        }
    }
}
