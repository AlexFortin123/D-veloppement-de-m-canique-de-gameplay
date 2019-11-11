using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonController : MonoBehaviour
{
    public TotemControlleur m_TotemControlleur;

    private void Awake()
    {
        m_TotemControlleur = this.GetComponentInParent<TotemControlleur>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_TotemControlleur.m_Activated = true;
            Destroy(gameObject);
            //Destroy(gameObject.GetComponent<CapsuleCollider>());
        }
    }
}
