using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementLineaire : MonoBehaviour
{
    private Vector3 m_StartPos;
    public Vector3 m_EndPos;
    public float m_ProgressionPercentage;

    private float m_Distance;

    // Start is called before the first frame update
    void Start()
    {
        m_StartPos = transform.position;
        m_ProgressionPercentage = 0f;

        m_Distance = Vector3.Distance(m_StartPos, m_EndPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ProgressionPercentage < 1f)
        {
            m_ProgressionPercentage += Time.deltaTime / m_Distance;
        }

        transform.position = Vector3.Lerp(m_StartPos, m_EndPos, m_ProgressionPercentage);

        //Debug.Log(m_ProgressionPercentage);
    }
}