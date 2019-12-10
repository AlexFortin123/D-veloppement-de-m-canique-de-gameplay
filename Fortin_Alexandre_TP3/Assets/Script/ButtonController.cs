using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool m_CanOpenDoor;

    private void Awake()
    {
        m_CanOpenDoor = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "ClonePlayer")
        {
            m_CanOpenDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "ClonePlayer")
        {
            m_CanOpenDoor = false;
        }
    }

    public bool GetCanOpenDoor()
    {
        return m_CanOpenDoor;
    }
}
