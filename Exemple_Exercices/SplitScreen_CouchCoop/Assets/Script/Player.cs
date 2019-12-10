using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_PlayerRigidBody;
    private Vector3 m_Direction;

    public float m_Speed;

    public KeyCode m_Avance;
    public KeyCode m_Recule;
    public KeyCode m_Gauche;
    public KeyCode m_Droite;

    private void Awake()
    {
        m_PlayerRigidBody = GetComponent<Rigidbody>();
        m_Direction = new Vector3();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(m_Gauche))
        {
            m_Direction.x = -1f;
        }
        else if(Input.GetKey(m_Droite))
        {
            m_Direction.x = 1f;
        }
        else
        {
            m_Direction.x = 0f;
        }

        if (Input.GetKey(m_Recule))
        {
            m_Direction.z = -1f;
        }
        else if (Input.GetKey(m_Avance))
        {
            m_Direction.z = 1f;
        }
        else
        {
            m_Direction.z = 0f;
        }

        m_Direction.Normalize();
        m_Direction *= m_Speed;
        m_Direction.y = m_PlayerRigidBody.velocity.y;

        m_PlayerRigidBody.velocity = m_Direction;
    }
}
