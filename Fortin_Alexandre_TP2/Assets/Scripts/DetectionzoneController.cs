using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionzoneController : MonoBehaviour
{
    public bool m_ObjectDetected;

    public EnnemisController m_ParentObejectAttached;
    // Start is called before the first frame update
    void Awake()
    {
        m_ParentObejectAttached = this.GetComponentInParent<EnnemisController>();
        m_ObjectDetected = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_ParentObejectAttached.m_PlayerDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_ParentObejectAttached.m_PlayerDetected = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_ParentObejectAttached.ManageTargetTransform(other.gameObject.transform);
        }
    }
}
