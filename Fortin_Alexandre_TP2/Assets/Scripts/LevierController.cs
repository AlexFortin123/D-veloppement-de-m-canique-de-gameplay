using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevierController : MonoBehaviour
{
    public GameObject m_Porte;
    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(m_Porte);
        }
    }
}
