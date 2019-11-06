using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Speed;
    public Rigidbody m_rigidBody;
    public string m_BulletObjectCollideDestroyNameTag;

    private Camera m_Camera;
    private float m_TimerBeforeDissapear;

    private void Awake()
    {
        m_Camera = Camera.main;
        m_TimerBeforeDissapear = 2f;
    }
    
    void Update()
    {
        
        if(m_TimerBeforeDissapear < 0)
        {
            Destroy(gameObject);
        }
        m_TimerBeforeDissapear -= Time.deltaTime;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == m_BulletObjectCollideDestroyNameTag)
        {
            Destroy(gameObject);
        }
    }
}
