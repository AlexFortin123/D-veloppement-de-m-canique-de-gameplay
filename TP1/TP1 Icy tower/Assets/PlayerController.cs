using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
    public float turnSpeed = 10f;
	Vector3 velocity;
    public float jumpSpeed = 200f;
    public float x_speed;
    public float z_speed;
    Scene scene;
    RaycastHit hit;
    public Camera a;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //prend les composant du rigidBody du joueur et les mets dans rb
        rb.freezeRotation = true; // empêche le cube de tourne
        scene = SceneManager.GetActiveScene();

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

        if (transform.position.y <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
        if (a.ViewportToWorldPoint(new Vector3(1, transform.position.y, transform.position.z)).x > transform.position.x)
        {
            Debug.Log("droite");
        }
        if (a.ViewportToWorldPoint(new Vector3(0, transform.position.y, transform.position.z)).x < transform.position.x)
        {
            Debug.Log("gauche");
        }
    }

    private void FixedUpdate()
    {
        //sequence qui définie la réaction du joueur au contact des objets
        LayerMask mask_Floor = LayerMask.GetMask("Floor");
        LayerMask mask_Danger = LayerMask.GetMask("Danger");
        
        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Floor) && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpSpeed, 0);// addForce donne un coup vers une position
        }
        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 0.5f, mask_Danger))
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
