using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
    public float turnSpeed = 10f;
	Vector3 velocity;
    Vector3 newPos;
    public float jumpSpeed = 200f;
    public float x_speed;
    public float z_speed;
    Scene scene;
    RaycastHit hit;
    public Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //prend les composant du rigidBody du joueur et les mets dans rb
        rb.freezeRotation = true; // empêche le cube de tourne
        scene = SceneManager.GetActiveScene();
        newPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        velocity = transform.InverseTransformDirection(rb.velocity);//prend les valeurs de la velocité global et les mets local

        //mouvement du joueur en x
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = x_speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -x_speed;
        }
        else
        {
            velocity.x = 0f;
        }

        rb.velocity = transform.TransformDirection(velocity);

        newPos = transform.position;
        //si le joueur sort de la vue de ma camera, il revien de l'autre côter, (0,0) en bas a gauche et (1,1) en haut a droite
        if (m_camera.WorldToViewportPoint(transform.position).x <= 0)
        {
            newPos.x = m_camera.transform.position.x + 15f;
        }
        if (m_camera.WorldToViewportPoint(transform.position).x >= 1)
        {
            newPos.x = m_camera.transform.position.x - 15f;
        }
        transform.position = newPos;

        //sequence qui définie la réaction du joueur au contact des objets
        LayerMask mask_Floor = LayerMask.GetMask("Floor");
        LayerMask mask_Danger = LayerMask.GetMask("Danger");

        if ((Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Floor) && Input.GetKeyDown(KeyCode.Space)) ||
            Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Floor) && Input.GetKeyDown(KeyCode.Space) ||
            Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Floor) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpSpeed, 0);// donne un coup vers une position
        }
        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Danger) ||
            Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Danger) ||
            Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Danger))
        {
            SceneManager.LoadScene(scene.name);
        }
        if (Physics.Raycast(transform.position, new Vector3(1f, 0f, 0f), out hit, 0.5f, mask_Danger) ||
            Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), new Vector3(1f, 0f, 0f), out hit, 0.5f, mask_Danger) ||
            Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), new Vector3(1f, 0f, 0f), out hit, 0.5f, mask_Danger))
        {
            SceneManager.LoadScene(scene.name);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1f, 0f, 0f), out hit, 0.5f, mask_Danger) ||
            Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), new Vector3(-1f, 0f, 0f), out hit, 0.5f, mask_Danger) ||
            Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), new Vector3(-1f, 0f, 0f), out hit, 0.5f, mask_Danger))
        {
            SceneManager.LoadScene(scene.name);
        }
        //si le joueur sort de l'écran vers le bas, il meurt et je jeu recommence
        if (m_camera.WorldToViewportPoint(transform.position).y <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
