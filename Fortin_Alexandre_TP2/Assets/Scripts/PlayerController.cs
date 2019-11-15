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
    private float m_Distance;
    private float m_Speed;
    private Scene scene;
    private CameraFollow m_CameraFellow;
    private bool m_ObjectInFRontOfPlayer;
   
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        m_CameraFellow = m_Camera.GetComponent<CameraFollow>();
        m_ObjectInFRontOfPlayer = false;
    }

    void Update()
    {
        if(m_CameraFellow.m_OtherCanMove)
        {
            m_startingPoint = transform.position;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
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
                    if (hit.collider.tag == "Floor")
                    {
                        Ray rays = new Ray();
                        rays.origin = transform.position + Vector3.up;
                        rays.direction = transform.forward;
                        Debug.DrawRay(rays.origin, rays.direction * 2f, Color.green);
                        RaycastHit hitWall;
                        if(Physics.Raycast(rays, out hitWall, 0.5f, LayerMask.GetMask("Ignore Raycast")))
                        {
                            Debug.Log("Allo");
                            m_ObjectInFRontOfPlayer = true;
                        }
                        else
                        {
                            m_ObjectInFRontOfPlayer = false;
                        }
                        if(!m_ObjectInFRontOfPlayer)
                        {
                            m_Distance = Vector3.Distance(transform.position, hit.point);
                            m_Speed = m_Distance / 20f;
                            transform.position = Vector3.Lerp(m_startingPoint, hit.point, Time.deltaTime / m_Speed);
                        }
                    }
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
        if(collision.gameObject.tag == "Fin")
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}