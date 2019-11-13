using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
    {
    public Camera m_Camera;
    public GameObject m_Balle;
    public int m_Hp;

    private Vector3 m_startingPoint;
    private Vector3 m_EndingPoint;
    private float m_Percentage;
    private float m_Distance;
    private float m_Speed;
    private Scene scene;
    
    // Start is called before the first frame update
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
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
                transform.LookAt(hit.point);
                if (hit.collider.tag == "Ennemy")
                {
                    GameObject projectileGameObject = GameObject.Instantiate(m_Balle, transform.position, Quaternion.identity);
                    projectileGameObject.transform.rotation = transform.rotation;
                    projectileGameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                transform.LookAt(hit.point);
                if (hit.collider.tag == "Floor"|| hit.collider.tag == "Levier")
                {
                    m_Distance = Vector3.Distance(transform.position, hit.point);
                    m_Speed = m_Distance / 20f;
                    transform.position = Vector3.Lerp(m_startingPoint, hit.point, Time.deltaTime / m_Speed);
                }
            }
        }
        if(m_Hp <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet_Ennemy")
        {
            m_Hp--;
        }
    }
}