using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesOperator : MonoBehaviour
{
    float m_Result = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(m_Result);
        m_Result = m_Result + 1f;
        Debug.Log(m_Result);
        m_Result += 1f;
        Debug.Log(m_Result);

        m_Result = m_Result - 1f;
        Debug.Log(m_Result);
        m_Result -= 1f;
        Debug.Log(m_Result);

        m_Result = 5f;
        m_Result = m_Result * 5f;
        Debug.Log(m_Result);
        m_Result *= 2f;
        Debug.Log(m_Result);

        m_Result = m_Result / 5f;
        Debug.Log(m_Result);
        m_Result /= 2f;
        Debug.Log(m_Result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
