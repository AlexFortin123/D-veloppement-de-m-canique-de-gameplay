using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script qui définie le comportement d'un projectile une fois qui est tirer dans le jeu
 */

public class Projectile : MonoBehaviour
{
    public float m_Speed;
    public Rigidbody m_rigidBody;
    public string m_BulletObjectCollideDestroyNameTag;
    public string m_BulletObjectCollideDestroyNameTag2;
    
    private float m_TimerBeforeDissapear;

    private void Awake()
    {
        m_TimerBeforeDissapear = 2f;
    }
    
    void Update()
    {
        //Après 2 seconde la balle est détruite
        if(m_TimerBeforeDissapear <= 0)
        {
            Destroy(gameObject);
        }
        m_TimerBeforeDissapear -= Time.deltaTime;


    }
    private void OnCollisionEnter(Collision collision)
    {
        //Si la balle entre en contact avec les objects qui porte les tags transmit a la balle
        if(collision.gameObject.tag == m_BulletObjectCollideDestroyNameTag || collision.gameObject.tag == m_BulletObjectCollideDestroyNameTag2)
        {
            Destroy(gameObject);
        }
    }
}
