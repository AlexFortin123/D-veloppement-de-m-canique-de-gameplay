using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script qui définie le comportement d'un totem, une fois que le joueur rentre en collision avec le boutton enfant du totem, se dernier
 * active un rayon qui va vers la position désirer et les deux sphères flottantes se mettent à tourner et le bouton disparait et on addition 1 
 * au nombre de totem activer
 */

public class TotemControlleur : MonoBehaviour
{
    public Transform m_DepartRayCast;
    public Transform m_FinRayCast;
    public bool m_Activated;
    public GameObject m_OeilPrincipal;

    private LineRenderer m_lineRenderer;
    private bool m_CanTurn;
    private OeilPrincipalController m_oeilPrincipalController;

    private void Awake()
    {
        m_CanTurn = false;
        m_oeilPrincipalController = m_OeilPrincipal.GetComponent<OeilPrincipalController>();

    }
    void Update()
    {
        if(m_Activated)
        {
            m_lineRenderer = this.gameObject.AddComponent<LineRenderer>();
            m_lineRenderer.SetPosition(0, m_DepartRayCast.position);
            m_lineRenderer.SetPosition(1, m_FinRayCast.position);
            m_Activated = false; // On remet a false pour éviter q'unity fasse apparaitre des linerenderer a chaque frame
            m_CanTurn = true;
            m_oeilPrincipalController.m_TotemActivated++;
        }
        //fait tourner les spheres
        if(m_CanTurn)
        {
            gameObject.transform.GetChild(0).transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
            gameObject.transform.GetChild(1).transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
