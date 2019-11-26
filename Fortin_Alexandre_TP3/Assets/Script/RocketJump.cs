using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJump : MonoBehaviour
{
    public GameObject m_Player;

    private PlayerController m_PlayerController;

    private void Awake()
    {
        m_PlayerController = m_Player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_PlayerController.SetJumpForce();
        }
    }
}
