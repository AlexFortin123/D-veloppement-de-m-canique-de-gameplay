using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_Speed;
    public float m_JumpForce;
    public GameManager m_GameManager;

    private Rigidbody m_RigidbodyPlayer;
    private Vector3 m_Velocity;
    private RaycastHit m_HitFloor;

    private void Awake()
    {
        m_RigidbodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();

        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    void Mouvement()
    {
        m_Velocity = m_RigidbodyPlayer.velocity;
        m_Velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            m_Velocity += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_Velocity += -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_Velocity += transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_Velocity += -transform.right;
        }

        m_Velocity.Normalize();
        m_Velocity *= m_Speed;
        m_Velocity.y = m_RigidbodyPlayer.velocity.y;


        m_RigidbodyPlayer.velocity = m_Velocity;
    }

    void Jump()
    {
       
        if(Physics.Raycast(transform.position, new Vector3(0,-1,0), 0.6f, LayerMask.GetMask("Floor")))
        {
            m_RigidbodyPlayer.AddForce(Vector3.up * m_JumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Reward")
        {
            m_GameManager.PlayerGetReward();
        }
    }
}
