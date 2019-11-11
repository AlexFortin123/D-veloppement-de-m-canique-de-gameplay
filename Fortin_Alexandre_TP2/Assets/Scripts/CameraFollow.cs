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
    public Vector3 m_NewPosCinematic;
    public bool m_CanMouveWithPlayer;

    private Vector3 m_NewPos;
    private float m_Pourcentage;
    private bool m_BackToInitialPosition;
    

    private void Awake()
    {
        m_CanMouveWithPlayer = true;
        m_Pourcentage = 0f;
        m_BackToInitialPosition = false;
    }
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
            if(m_CanMouveWithPlayer)
            {
                m_NewPos = m_Player.transform.position;
                m_NewPos.x = Mathf.Clamp(m_NewPos.x, m_BordureMapGauche.position.x, m_BordureMapDroite.position.x);
                m_NewPos.z = Mathf.Clamp(m_NewPos.z - 12f, m_BordureMapBas.position.z, m_BordureMapHaut.position.z);
                m_NewPos.y = m_Player.transform.position.y + 12f;
                transform.position = m_NewPos;
            }
            else
            {
                float distance;
                if(!m_BackToInitialPosition)
                {
                    distance = Vector3.Distance(transform.position, m_NewPosCinematic);
                    transform.position = Vector3.Lerp(transform.position, m_NewPosCinematic, m_Pourcentage / distance);
                    if (m_Pourcentage >= 100)
                    {
                        m_BackToInitialPosition = true;
                        m_Pourcentage = 0;
                    }
                    m_Pourcentage += 30f * Time.deltaTime;
                }
                else
                {
                    //m_Pourcentage = 0;
                    distance = Vector3.Distance(transform.position, m_NewPosCinematic);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(m_Player.transform.position.x,
                        m_Player.transform.position.y + 12f, m_Player.transform.position.z - 12f), m_Pourcentage / distance);
                    if (m_Pourcentage >= 100)
                    {
                        m_CanMouveWithPlayer = true;
                        m_BackToInitialPosition = false;
                        m_Pourcentage = 0;
                    }
                    m_Pourcentage += 30f * Time.deltaTime;
                }
            }
            
        }
        
    }
}
