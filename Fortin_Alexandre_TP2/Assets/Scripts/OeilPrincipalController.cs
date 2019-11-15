using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script qui permet de faire appraître la zone de fin ou le joueur doit se rendre pour gagner après l'activation des 4 totem
 */

public class OeilPrincipalController : MonoBehaviour
{
    public float m_TotemActivated;
    public GameObject m_BodyToAppear;
    
    private Vector3 m_PosAppearBodyOeilPrincipal;
    private Camera m_MainCamera;
    private LineRenderer m_lineRenderer;

    private void Awake()
    {
        m_TotemActivated = 0;
        m_PosAppearBodyOeilPrincipal = new Vector3(transform.position.x, transform.position.y - 15.8f, transform.position.z);
        m_MainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        //si les 4 totem sont activé, on fait apparaître le body (appraître la zone de fin) et un ligne vers le bas
        if (m_TotemActivated == 4)
        {
            GameObject bodyOeilPrincipal = GameObject.Instantiate(m_BodyToAppear, m_PosAppearBodyOeilPrincipal, Quaternion.identity);
            bodyOeilPrincipal.transform.rotation = transform.rotation;
            m_lineRenderer = this.gameObject.AddComponent<LineRenderer>();
            m_lineRenderer.SetPosition(0, transform.position);
            m_lineRenderer.SetPosition(1, bodyOeilPrincipal.transform.position);
            m_TotemActivated--; //Pour éviter que unity fasse apparaître des body à l'infinie
        }
    }
}
