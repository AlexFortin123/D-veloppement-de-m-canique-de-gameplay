using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(m_TotemActivated == 4)
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
