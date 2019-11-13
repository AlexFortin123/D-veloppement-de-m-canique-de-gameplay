using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemControlleur : MonoBehaviour
{
    public Transform m_DepartRayCast;
    public Transform m_FinRayCast;
    public bool m_Activated;
    public GameObject m_OeilPrincipal;

    private LineRenderer m_lineRenderer;
    private bool m_CanTurn;
    private OeilPrincipalController m_oeilPrincipalController;
    // Update is called once per frame
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
            m_Activated = false;
            m_CanTurn = true;
            m_oeilPrincipalController.m_TotemActivated++;
        }
        if(m_CanTurn)
        {
            gameObject.transform.GetChild(0).transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
            gameObject.transform.GetChild(1).transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
