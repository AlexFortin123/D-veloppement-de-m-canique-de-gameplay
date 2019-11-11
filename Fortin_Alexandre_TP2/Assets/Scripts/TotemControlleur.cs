using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemControlleur : MonoBehaviour
{
    public Transform m_DepartRayCast;
    public Transform m_FinRayCast;
    public bool m_Activated;

    private LineRenderer m_lineRenderer;
    // Update is called once per frame
    private void Awake()
    {
    }
    void Update()
    {
        if(m_Activated)
        {
            m_lineRenderer = this.gameObject.AddComponent<LineRenderer>();
            m_lineRenderer.SetPosition(0, m_DepartRayCast.position);
            m_lineRenderer.SetPosition(1, m_FinRayCast.position);
            m_Activated = false;
        }
    }
}
