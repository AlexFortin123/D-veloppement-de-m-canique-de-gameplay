using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge4 : MonoBehaviour
{
    public float m_Speed;

    private Rigidbody m_RbPlayer;
    private Vector3 m_NewVelocityPlayer;
    private List<Transform> m_ListTransformEnfant;

    private void Awake()
    {
        m_RbPlayer = GetComponent<Rigidbody>();
        m_ListTransformEnfant = new List<Transform>();
    }
    void Update()
    {
        Deplacement();
        if(Input.GetKey(KeyCode.Space))
        {
            for(int i = 0; i < m_ListTransformEnfant.Count; i++)
            {
                m_ListTransformEnfant[i].transform.position = transform.position;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            m_ListTransformEnfant.Add(collision.gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            m_ListTransformEnfant.Remove(collision.gameObject.transform);
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
