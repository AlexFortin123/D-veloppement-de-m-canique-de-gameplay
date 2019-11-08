using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_Player;
    public Transform m_BordureMapDroite;
    public Transform m_BordureMapGauche;
    public Transform m_BordureMapHaut;
    public Transform m_BordureMapBas;

    private Vector3 m_NewPos;
    
    void Update()
    {
        if(this.tag == "MinimapCamera")
        {
            m_NewPos = m_Player.transform.position;
            m_NewPos.y = m_Player.transform.position.y + 100f;
            transform.position = m_NewPos;
        }
        else
        {
            m_NewPos = m_Player.transform.position;
            m_NewPos.x = Mathf.Clamp(m_NewPos.x, m_BordureMapGauche.position.x, m_BordureMapDroite.position.x);
            m_NewPos.z = Mathf.Clamp(m_NewPos.z - 12f, m_BordureMapBas.position.z, m_BordureMapHaut.position.z);
            m_NewPos.y = m_Player.transform.position.y + 12f;
            transform.position = m_NewPos;
        }
        
    }
}
