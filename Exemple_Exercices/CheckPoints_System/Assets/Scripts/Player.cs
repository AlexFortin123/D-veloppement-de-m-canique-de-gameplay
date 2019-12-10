using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private Vector3 m_Direction;
    public float m_Speed = 5f;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_Direction.x = -1f;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            m_Direction.x = 1f;
        }
        else
        {
            m_Direction.x = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_Direction.z = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_Direction.z = -1f;
        }
        else
        {
            m_Direction.z = 0f;
        }

        m_Direction.Normalize();
        m_Direction *= m_Speed;

        m_Direction.y = m_RigidBody.velocity.y;

        m_RigidBody.velocity = m_Direction;
    }
}
