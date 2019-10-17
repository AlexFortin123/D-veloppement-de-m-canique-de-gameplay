using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Speed;
    public GameObject m_Tireur;
    private Vector3 m_Pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Pos = transform.position;
        m_Pos.z += m_Speed;
        transform.position = m_Pos;
        
        if(Vector3.Distance(m_Tireur.transform.position, transform.position) > 50f)
        {
            Destroy(gameObject);
        }
    }
}
