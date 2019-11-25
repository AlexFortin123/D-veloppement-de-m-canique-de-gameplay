using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_SpeedMouvementPlayer;
    public float m_JumpForcePlayer;
    public Rigidbody m_RigidbodyPlayer;

    private Vector3 m_VelocityPlayer;

    private void Awake()
    {
        m_RigidbodyPlayer = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        m_VelocityPlayer = m_RigidbodyPlayer.velocity;
        if (Input.GetKey(KeyCode.W))
        {
            m_VelocityPlayer = transform.forward * m_SpeedMouvementPlayer;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_VelocityPlayer = transform.forward * -m_SpeedMouvementPlayer;
        }
        else
        {
            m_VelocityPlayer = Vector3.zero;
        }
        m_RigidbodyPlayer.velocity = m_VelocityPlayer;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_RigidbodyPlayer.AddForce(Vector3.up * m_JumpForcePlayer);
        }
    }
}
