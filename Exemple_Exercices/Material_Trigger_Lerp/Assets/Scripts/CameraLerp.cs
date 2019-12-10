using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Vector3 m_Start;
    public Vector3 m_End;

    private float m_Percentage;
    // Start is called before the first frame update
    void Start()
    {
        m_Percentage = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //m_Percentage += 0.01f;

        //m_Percentage += Time.deltaTime / 5f;
        m_Percentage += Time.deltaTime * 0.2f;

        // 60fps = 0.0167

        // 200fps = 0.005

        // Vector3.x = 5f * Time.deltaTime;

        if(m_Percentage >= 1f)
        {
            m_Percentage = 1f;
        }

        transform.position = Vector3.Lerp(m_Start, m_End, m_Percentage);
    }
}
