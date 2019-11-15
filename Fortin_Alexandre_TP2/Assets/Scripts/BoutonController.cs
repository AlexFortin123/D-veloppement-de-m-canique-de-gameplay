using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script qui permet d'activé le totem avec lequel le boutton est enfants
 * sa envoie un signal au Totem pour qu'il s'active lors de la collision
 * entre le joueur et le boutton
 */
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
        }
    }
}
