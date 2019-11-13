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
    public Transform m_NewTranformCinematic;
    public Transform m_InitialPositionCamera;
    public bool m_CanMouveWithPlayer;

    private Vector3 m_NewPos;
    private Vector3 m_PositionPlayer;
    private float m_Pourcentage;
    private bool m_BackToInitialPosition;
    private Quaternion m_QuaternionInitialCamera;
    

    private void Awake()
    {
        m_CanMouveWithPlayer = true;
        m_Pourcentage = 0f;
        m_BackToInitialPosition = false;
        m_QuaternionInitialCamera = transform.rotation;
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
                if(!m_BackToInitialPosition)
                {
                    transform.position = Vector3.Lerp(m_InitialPositionCamera.position, m_NewTranformCinematic.position, m_Pourcentage);
                    transform.rotation = Quaternion.Lerp(m_InitialPositionCamera.rotation, m_NewTranformCinematic.rotation, m_Pourcentage);
                    m_Pourcentage += 0.3f * Time.deltaTime;
                    if (m_Pourcentage >= 1f)
                    {
                        m_BackToInitialPosition = true;
                        m_Pourcentage = 0;
                        m_PositionPlayer = new Vector3(m_Player.transform.position.x,
                        m_Player.transform.position.y + 12f, m_Player.transform.position.z - 12f);
                    }
                }
                else
                {
                    transform.position = Vector3.Lerp(m_NewTranformCinematic.position, m_PositionPlayer, m_Pourcentage);
                    transform.rotation = Quaternion.Lerp(m_NewTranformCinematic.rotation, m_QuaternionInitialCamera, m_Pourcentage);
                    m_Pourcentage += 0.3f * Time.deltaTime;
                    if (m_Pourcentage >= 1f)
                    {
                        m_CanMouveWithPlayer = true;
                        m_BackToInitialPosition = false;
                        m_Pourcentage = 0;
                    }
                }
            }
            
        }
        
    }
}
