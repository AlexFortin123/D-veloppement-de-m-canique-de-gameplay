using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteurControlleur : MonoBehaviour
{
    public GameObject m_Player;
    public Transform m_TeleporteurLie;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_Player.transform.position = new Vector3(m_TeleporteurLie.position.x, m_TeleporteurLie.position.y, m_TeleporteurLie.position.z + 2f);
        }
    }
}
