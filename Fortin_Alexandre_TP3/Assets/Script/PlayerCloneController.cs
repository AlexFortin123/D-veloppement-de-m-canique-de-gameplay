using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloneController : MonoBehaviour
{
    public GameObject m_Player;
    public Rigidbody m_ClonePlayerRigidbody;

    private Vector3 m_VelocityClonePlayer;
    private PlayerController m_PlayerController;
    private float m_SpeedMouvementClonePlayer;
    private float m_JumpForceClonePlayer;

    private void Awake()
    {
        //m_PlayerController = m_Player.GetComponent<PlayerController>();
        m_ClonePlayerRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        m_PlayerController = m_Player.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = m_Player.transform.rotation;
        m_SpeedMouvementClonePlayer = m_PlayerController.m_SpeedMouvementPlayer;
        m_JumpForceClonePlayer = m_PlayerController.m_JumpForcePlayer;

        m_VelocityClonePlayer = m_ClonePlayerRigidbody.velocity;
        if (Input.GetKey(KeyCode.W))
        {
            m_VelocityClonePlayer = transform.forward * m_SpeedMouvementClonePlayer;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_VelocityClonePlayer = transform.forward * -m_SpeedMouvementClonePlayer;
        }
        else
        {
            m_VelocityClonePlayer = Vector3.zero;
        }
        m_ClonePlayerRigidbody.velocity = m_VelocityClonePlayer;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ClonePlayerRigidbody.AddForce(0, m_JumpForceClonePlayer, 0);
        }
    }
}
