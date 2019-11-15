using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*Script qui détermine le comportement du joueur et ses intéractions avec l'environnement
 */

public class PlayerController : MonoBehaviour
    {
    public Camera m_Camera;
    public GameObject m_Balle;
    public int m_Hp;
    public Slider m_HealthBarSlider;
    public Text m_HealthBarText;

    private Vector3 m_startingPoint;
    private Vector3 m_EndingPoint;
    private float m_Distance;
    private float m_Speed;
    private float m_CurrentHealth;
    private Scene scene;
    private CameraFollow m_CameraFellow;
    private bool m_ObjectInFRontOfPlayer;
   
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        m_CameraFellow = m_Camera.GetComponent<CameraFollow>();
        m_ObjectInFRontOfPlayer = false;
        m_CurrentHealth = m_Hp;
        m_HealthBarSlider.maxValue = m_Hp;
    }

    void Update()
    {
        m_HealthBarSlider.value = m_CurrentHealth; //set la valeur du slider au nombre de pv du joueur
        m_HealthBarText.text = m_CurrentHealth.ToString() + " / " + m_Hp.ToString(); // affiche le nombre de pv restant sur les pv max

        //premier if qui interdit au joueur de bouger si la camera se déplace dans ses lerps
        if (m_CameraFellow.m_OtherCanMove)
        {
            //zone de code qui permet de de tirer sur un ennmis lorsque le joueur click sur l'ennemis
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
            //Déplacement du joueur lorsque se dernier garde le bouton gauche enfoncer
            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    transform.LookAt(hit.point);

                    //Le joueur ne peut bouger que si le joueur click sur le floor
                    if (hit.collider.tag == "Floor")
                    {
                        Ray rays = new Ray();
                        rays.origin = transform.position + Vector3.up;
                        rays.direction = transform.forward;
                        RaycastHit hitObject;

                        //Le if permet d'éviter au joueur de passer a travers les mur
                        if(Physics.Raycast(rays, out hitObject, 0.5f, LayerMask.GetMask("Ignore Raycast"))
                            && (hitObject.transform.tag == "Wall" || hitObject.transform.tag == "Porte"))
                        {
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
        
        //Si le joueur meurt, On reload la game
        if(m_CurrentHealth <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
        //si le joueur appuie sur le bouton R, il recommence au début du jeu
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(scene.name);
        }
        //si le joueur appuie sur le bouton Escape, il revient au MainMenu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si le joueur est touché par les balles des ennemis, il pert de la vie
        if(collision.gameObject.tag == "Bullet_Ennemy")
        {
            m_CurrentHealth--;
        }
        //Si le joueur rentre en collision avec la plateforme de fin, il revient à l'écran titre
        if(collision.gameObject.tag == "Fin")
        {
            SceneManager.LoadScene(scene.name);
        }
        //si le joueur touche un totem de vie, il regagne toute sa vie et désactive le totem
        if (collision.gameObject.tag == "Heal")
        {
            m_CurrentHealth = m_Hp;
            collision.gameObject.GetComponent<Renderer>().material.color = Color.gray;
            Destroy(collision.gameObject.GetComponent<BoxCollider>());
        }
    }
}