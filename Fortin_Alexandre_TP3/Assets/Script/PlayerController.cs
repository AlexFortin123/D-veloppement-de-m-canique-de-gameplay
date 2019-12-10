using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script qui définie le comportement du player
public class PlayerController : MonoBehaviour
{
    public float m_SpeedMouvementPlayer;
    public float m_JumpForcePlayer;
    public Vector3 m_NewScaleShrinkPlayer;
    public Rigidbody m_RigidbodyPlayer;
    public GameObject m_ClonePlayer;
    public bool m_CanDestroyClones;
    public GameManager m_GameManager;

    private Vector3 m_VelocityPlayer;
    private Vector3 m_ScalePlayerDefault;
    private float m_SpeedMouvementPlayerDefault;
    private float m_JumpForcePlayerDefault;
    private RaycastHit m_Hit;

    private void Awake()
    {
        m_RigidbodyPlayer = GetComponent<Rigidbody>();
        m_SpeedMouvementPlayerDefault = m_SpeedMouvementPlayer;
        m_JumpForcePlayerDefault = m_JumpForcePlayer;
        m_ScalePlayerDefault = transform.localScale;
        m_CanDestroyClones = false;
    }

    void Update()
    {
        Mouvement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ResetButton")
        {
            ResetPlayerStat();
            m_GameManager.ResetButtonActivated();
        }
        if(other.gameObject.tag == "CloneButton")
        {
            CreateClonePlayer(other.gameObject.transform.GetChild(2).transform);
            m_GameManager.CloneButtonActivated();
        }
        if(other.gameObject.tag == "ShrinkButton")
        {
            Shrink();
            m_GameManager.ShrinkButtonActivated();
        }
        if(other.gameObject.tag == "RocketJump")
        {
            SetJumpForce();
            m_GameManager.RocketJumpActivated();
        }
        if(other.gameObject.tag == "DoubleSpeed")
        {
            DoubleSpeed();
            m_GameManager.DoubleSpeedButtonActivated();
        }
        if(other.gameObject.tag == "MovingPlateforme")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlateforme")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlateforme")
        {
            transform.parent = null;
        }
    }

    public void SetJumpForce()
    {
        m_JumpForcePlayer *= 2f;
    }

    public void ResetPlayerStat()
    {
        m_SpeedMouvementPlayer = m_SpeedMouvementPlayerDefault;
        m_JumpForcePlayer = m_JumpForcePlayerDefault;
        transform.localScale = m_ScalePlayerDefault;
        m_CanDestroyClones = true;
        
    }

    public void CreateClonePlayer(Transform i_SpawnTransform)
    {
        GameObject ClonePlayer = GameObject.Instantiate(m_ClonePlayer, i_SpawnTransform.position, Quaternion.identity);
        ClonePlayer.GetComponent<PlayerCloneController>().SetPlayer(this);
    }

    public void Shrink()
    {
        transform.localScale = m_NewScaleShrinkPlayer;
    }

    private void Mouvement()
    {
        //Reset la valeur de x,y,z pour remettre mon vecteur a zero ainsi réinitialiser mon vecteur a zero
        m_VelocityPlayer.x = 0f;
        m_VelocityPlayer.z = 0f;
        m_VelocityPlayer.y = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            m_VelocityPlayer += -transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_VelocityPlayer += transform.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_VelocityPlayer += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_VelocityPlayer += -transform.forward;
        }

        m_VelocityPlayer.Normalize(); //permet de mettre la valeur égale dans toutes les directions
        m_VelocityPlayer *= m_SpeedMouvementPlayer;
        m_VelocityPlayer.y = m_RigidbodyPlayer.velocity.y; // pour éviter de toujours reset la velocity en y, il faut qu'elle soit égale a celle du rigidbody

        m_RigidbodyPlayer.velocity = m_VelocityPlayer;
    }

    private void Jump()
    {
        LayerMask mask_Floor = LayerMask.GetMask("Floor");
        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out m_Hit, 0.6f, mask_Floor) ||
            Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out m_Hit, 0.6f, mask_Floor) ||
            Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out m_Hit, 0.6f, mask_Floor))
        {
            m_RigidbodyPlayer.AddForce(0, m_JumpForcePlayer, 0);
        }
    }

    private void DoubleSpeed()
    {
        m_SpeedMouvementPlayer *= 2f;
    }

}
