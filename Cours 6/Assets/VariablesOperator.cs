using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesOperator : MonoBehaviour
{
    float m_result = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //exemple d'opérateur
        Debug.Log(m_result);
        m_result = m_result + 1f;
        Debug.Log(m_result);
        m_result += 1f;

        Debug.Log(m_result);
        m_result = m_result - 1f;
        Debug.Log(m_result);
        m_result -= 1f;

        m_result = 5f;
        m_result = m_result * 5f;
        Debug.Log(m_result);
        m_result *= 2f;

        m_result = m_result / 5f;
        Debug.Log(m_result);
        m_result /= 2f;
        Debug.Log(m_result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
