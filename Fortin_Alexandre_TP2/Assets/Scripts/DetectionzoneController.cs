using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionzoneController : MonoBehaviour
{
    public bool m_ObjectDetected;
    public Transform m_TransformTarget;
    // Start is called before the first frame update
    void Awake()
    {
        m_ObjectDetected = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_ObjectDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_ObjectDetected = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_TransformTarget = other.gameObject.transform;
        }
    }
}
