using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameplayManager m_GameplayManager;

    //private bool m_IsCheckPointUsed = false;

    private BoxCollider m_BoxCollider;

    private void Awake()
    {
        m_BoxCollider = GetComponent<BoxCollider>(); ;
    }

    private void OnTriggerEnter(Collider other)
    {
        /* if(m_IsCheckPointUsed == false)
         {
             m_GameplayManager.SetLastCheckPoint(transform.position);
             m_IsCheckPointUsed = true;
         }*/

        m_GameplayManager.SetLastCheckPoint(transform.position);
        Destroy(gameObject);

        //m_GameplayManager.SetLastCheckPoint(transform.position);
        //m_BoxCollider.enabled = false;
    }

    // On Destroy est appeller juste avant que l'objet soit detruit et enlever de la hierarchy
    private void OnDestroy()
    {
        Debug.Log("Je suis détruit");
    }
}
