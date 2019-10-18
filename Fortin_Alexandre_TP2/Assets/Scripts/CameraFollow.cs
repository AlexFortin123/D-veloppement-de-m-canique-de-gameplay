using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_Player;
    private Vector3 m_NewPos;
    void Start()
    {
        
    }
    
    void Update()
    {
        m_NewPos = new Vector3(m_Player.transform.position.x, transform.position.y, m_Player.transform.position.z -12f);
        transform.position = m_NewPos;
    }
}
