using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouvement : MonoBehaviour
{
    public Vector3 m_LeftPos;
    public Vector3 m_RightPos;
    public float m_Speed;

    private float m_Pourcentage;
    private bool m_GoLeft;

    private void Awake()
    {
        m_Pourcentage = 0f;
        m_GoLeft = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(m_GoLeft)
        {
            transform.position = Vector3.Lerp(transform.position, m_LeftPos, m_Speed * Time.deltaTime);
            if(m_Pourcentage >= 1)
            {
                m_Pourcentage = 0f;
                m_GoLeft = false;
            }
            m_Pourcentage += m_Speed * Time.deltaTime ;
            //Debug.Log(m_Pourcentage);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, m_RightPos, m_Speed * Time.deltaTime);
            if (m_Pourcentage >= 1)
            {
                m_Pourcentage = 0f;
                m_GoLeft = true;
            }
            m_Pourcentage += (m_Speed * Time.deltaTime);
            //Debug.Log(m_Pourcentage);
        }
        
    }
}
