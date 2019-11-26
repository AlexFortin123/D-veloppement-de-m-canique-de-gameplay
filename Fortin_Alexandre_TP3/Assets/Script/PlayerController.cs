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

    private Vector3 m_VelocityPlayer;
    private Vector3 m_ScalePlayerDefault;
    private float m_SpeedMouvementPlayerDefault;
    private float m_JumpForcePlayerDefault;

    private void Awake()
    {
        m_RigidbodyPlayer = GetComponent<Rigidbody>();
        m_SpeedMouvementPlayerDefault = m_SpeedMouvementPlayer;
        m_JumpForcePlayerDefault = m_JumpForcePlayer;
        m_ScalePlayerDefault = transform.localScale;
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
            m_RigidbodyPlayer.AddForce(0 , m_JumpForcePlayer, 0);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ResetButton")
        {
            ResetPlayerStat();
        }
        if(other.gameObject.tag == "CloneButton")
        {
            CreateClonePlayer();
        }
        if(other.gameObject.tag == "ShrinkButton")
        {
            Shrink();
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
    }
    public void CreateClonePlayer()
    {
        GameObject ClonePlayer = GameObject.Instantiate(m_ClonePlayer, transform.position + transform.forward * 2f, Quaternion.identity);
        ClonePlayer.GetComponent<PlayerCloneController>().m_Player = gameObject;
        //ClonePlayer.GetComponent<PlayerController>().enabled = false;
    }
    public void Shrink()
    {
        transform.localScale = m_NewScaleShrinkPlayer;
    }
}
