using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Speed;
    public Rigidbody m_rigidBody;
    public string m_BulletObjectCollideDestroyNameTag;

    private Camera m_Camera;

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
        
        if(m_Camera.WorldToViewportPoint(transform.position).y >= 1 || m_Camera.WorldToViewportPoint(transform.position).y <= 0 
           || m_Camera.WorldToViewportPoint(transform.position).x >= 1 || m_Camera.WorldToViewportPoint(transform.position).x <= 0)
        {
            Destroy(gameObject);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == m_BulletObjectCollideDestroyNameTag)
        {
            Destroy(gameObject);
        }
    }
}
