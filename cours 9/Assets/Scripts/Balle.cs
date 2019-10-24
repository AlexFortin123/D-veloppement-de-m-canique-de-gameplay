using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public Player m_Player;
    Vector3 m_NewPos;
    // toujours caller les initiations dans le Awake()
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_NewPos = transform.position;
        m_NewPos.x += 0.5f;
        transform.position = m_NewPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            Destroy(gameObject);
        }
    }
}
