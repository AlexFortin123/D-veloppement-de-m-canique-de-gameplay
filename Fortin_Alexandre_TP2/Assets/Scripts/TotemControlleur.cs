using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemControlleur : MonoBehaviour
{
    public Transform m_DepartRayCast;
    public Transform m_FinRayCast;

    private LineRenderer m_lineRenderer;
    private bool m_DrawRayCast;
    // Update is called once per frame
    private void Awake()
    {
    }
    void Update()
    {
        if(m_DrawRayCast == true)
        {
            m_lineRenderer = this.gameObject.AddComponent<LineRenderer>();
            m_lineRenderer.SetPosition(0, m_DepartRayCast.position);
            m_lineRenderer.SetPosition(1, m_FinRayCast.position);
            m_DrawRayCast = false;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_DrawRayCast = true;
        }
    }
}
