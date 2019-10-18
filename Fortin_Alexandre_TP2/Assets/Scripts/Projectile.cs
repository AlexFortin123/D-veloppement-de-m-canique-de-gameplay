using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Speed;
    public GameObject m_Tireur;
    private Camera m_Camera;
    private Vector3 m_Pos;
    private void Awake()
    {
        m_Camera = Camera.main;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Pos = transform.position;
        m_Pos.z += m_Speed;
        transform.position = m_Pos;
        
        if(m_Camera.WorldToViewportPoint(transform.position).y >= 1 || m_Camera.WorldToViewportPoint(transform.position).y <= 0 
           || m_Camera.WorldToViewportPoint(transform.position).x >= 1 || m_Camera.WorldToViewportPoint(transform.position).x <= 0)
        {
            Destroy(gameObject);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("allo");
        if(collision.gameObject.tag == "Ennemy")
        {
            Destroy(gameObject);
        }
    }
}
