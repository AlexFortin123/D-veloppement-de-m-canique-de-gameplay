using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerController : MonoBehaviour
    {
    public Camera m_Camera;
    public GameObject m_Balle;
    private Vector3 m_startingPoint;
    private Vector3 m_EndingPoint;
    private float m_Percentage;
    private float m_Distance;
    private float m_Speed;
    // Start is called before the first frame update
    void Awake()
    {
        m_Percentage = 2f * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        //GetMouseButton
        m_startingPoint = transform.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Ennemy")
                {
                    GameObject projectileGameObject = GameObject.Instantiate(m_Balle, transform.position + Vector3.forward, Quaternion.identity);
                    Projectile projectile = projectileGameObject.GetComponent<Projectile>();
                    projectile.m_Tireur = gameObject;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Clickable")))
            {
                if (hit.collider.tag == "Floor")
                {
                    m_Distance = Vector3.Distance(transform.position, hit.point);
                    m_Speed = m_Distance / 20f;
                    transform.position = Vector3.Lerp(m_startingPoint, hit.point, Time.deltaTime / m_Speed);
                }
            }
        }
    }
}