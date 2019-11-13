using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    public Camera m_MainCamera;
    public Transform m_TransformNewPosCamera;

    private CameraFollow m_CameraFollow;

    private void Awake()
    {
        m_CameraFollow = m_MainCamera.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_CameraFollow.m_NewTranformCinematic = m_TransformNewPosCamera;
            m_CameraFollow.m_CanMouveWithPlayer = false;
            m_CameraFollow.m_InitialPositionCamera = m_MainCamera.transform;
        }
    }
}
