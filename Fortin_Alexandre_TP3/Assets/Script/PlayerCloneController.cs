using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloneController : MonoBehaviour
{
    public PlayerController m_PlayerController;
    public Rigidbody m_ClonePlayerRigidbody;

    private Vector3 m_VelocityClonePlayer;
    private float m_SpeedMouvementClonePlayer;
    private float m_JumpForceClonePlayer;
    private RaycastHit m_CloneHit;

    private void Awake()
    {
        m_ClonePlayerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MouvementClone();

        CloneJump();

        if (m_PlayerController.m_CanDestroyClones)
        {
            Destroy(gameObject);
            m_PlayerController.m_CanDestroyClones = false;
        }
    }

    public void SetPlayer(PlayerController i_PlayerController)
    {
        m_PlayerController = i_PlayerController;
    }

    private void MouvementClone()
    {
        transform.rotation = m_PlayerController.transform.rotation;
        m_SpeedMouvementClonePlayer = m_PlayerController.m_SpeedMouvementPlayer;
        transform.localScale = m_PlayerController.transform.localScale;

        //Reset la valeur de x,y,z pour remettre mon vecteur a zero ainsi réinitialiser mon vecteur a zero
        m_VelocityClonePlayer.x = 0f;
        m_VelocityClonePlayer.z = 0f;
        m_VelocityClonePlayer.y = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            m_VelocityClonePlayer += transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_VelocityClonePlayer += -transform.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_VelocityClonePlayer += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_VelocityClonePlayer += -transform.forward;
        }

        m_VelocityClonePlayer.Normalize(); //permet de mettre la valeur égale dans toutes les directions
        m_VelocityClonePlayer *= m_SpeedMouvementClonePlayer;
        m_VelocityClonePlayer.y = m_ClonePlayerRigidbody.velocity.y; // pour éviter de toujours reset la velocity en y, il faut qu'elle soit égale a celle du rigidbody

        m_ClonePlayerRigidbody.velocity = m_VelocityClonePlayer;
    }

    private void CloneJump()
    {
        m_JumpForceClonePlayer = m_PlayerController.m_JumpForcePlayer;
        LayerMask mask_Floor = LayerMask.GetMask("Floor");
        if ((Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out m_CloneHit, 0.5f, mask_Floor) && Input.GetKeyDown(KeyCode.Space)) ||
            Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out m_CloneHit, 0.6f, mask_Floor) && Input.GetKeyDown(KeyCode.Space) ||
            Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out m_CloneHit, 0.6f, mask_Floor) && Input.GetKeyDown(KeyCode.Space))
        {
            m_ClonePlayerRigidbody.AddForce(0, m_JumpForceClonePlayer, 0);
        }
    }
}
