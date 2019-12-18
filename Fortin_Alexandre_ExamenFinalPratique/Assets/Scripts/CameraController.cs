using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_PlayerTransform;

    private Vector3 m_NewPos;
    
    void Update()
    {
        m_NewPos = m_PlayerTransform.position;

        m_NewPos.z -= 5f;
        m_NewPos.y += 2.35f;

        transform.position = m_NewPos;
    }
}
