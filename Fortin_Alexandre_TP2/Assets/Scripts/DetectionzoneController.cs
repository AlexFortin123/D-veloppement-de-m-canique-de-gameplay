using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Scripts qui permet a la zone de détections de trnasmettre un signal et la position du joueur à son ennemis attaché
 */

public class DetectionzoneController : MonoBehaviour
{
    public EnnemisController m_ParentObejectAttached;

    void Awake()
    {
        m_ParentObejectAttached = this.GetComponentInParent<EnnemisController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Envoie signal que le joeuur est entré dans le trigger et que l'ennemis doit réagir
        if(other.gameObject.tag == "Player")
        {
            m_ParentObejectAttached.m_PlayerDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //envoie signal que le joueur est sortie du trigger et l'ennemi doit avoir son comportement originel
        if (other.gameObject.tag == "Player")
        {
            m_ParentObejectAttached.m_PlayerDetected = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Tant que le joueur est dans le trigger, la zone de détection transmet la position du joueur à l'ennemi
        if (other.gameObject.tag == "Player")
        {
            m_ParentObejectAttached.ManageTargetTransform(other.gameObject.transform);
        }
    }
}
