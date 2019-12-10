using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    Vector3 m_StartingPoint;
    Vector3 m_EndingPoint;
    float m_Percentage;

    bool m_Incrementing;

    // Start is called before the first frame update
    void Start()
    {
        m_StartingPoint = new Vector3(-10f, 0f, 6f);
        m_EndingPoint = new Vector3(10f, 0f, 6f);
        m_Percentage = 0f;

        m_Incrementing = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Percentage 0f = 0% de progression, donc on retourne le startingPoint
        // Percentage 1f = 100% de progression, donc on retourne le EndPoint

        transform.position = Vector3.Lerp(m_StartingPoint, m_EndingPoint, m_Percentage);


        // Incrémenter le percentage de progression du lerp, pour passé progressivement de 0f a 1f, donc passer du starting point au ending point
        if (m_Incrementing)
        {
            m_Percentage += (0.5f * Time.deltaTime);
            if (m_Percentage >= 1f)
            {
                m_Incrementing = false;
            }
        }
        else
        {
            m_Percentage -= (0.5f * Time.deltaTime);
            if (m_Percentage <= 0f)
            {
                m_Incrementing = true;
            }
        }
    }
}
