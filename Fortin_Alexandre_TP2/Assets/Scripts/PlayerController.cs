using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerController : MonoBehaviour
    {

    public UnityEngine.Camera m_Camera;
    private Vector3 m_startingPoint;
    private Vector3 m_EndingPoint;
    private float m_Percentage;
    // Start is called before the first frame update
    void Awake()
    {
        m_Percentage = 2f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        m_startingPoint = transform.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = 1 << 9;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100, layerMask))
            {
                transform.position = Vector3.Lerp(m_startingPoint, hit.point, m_Percentage);
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                transform.position = Vector3.Lerp(m_startingPoint, hit.point, m_Percentage);
            }
        }
    }
}