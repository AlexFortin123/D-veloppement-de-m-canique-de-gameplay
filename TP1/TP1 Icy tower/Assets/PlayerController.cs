using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
    public float turnSpeed = 10f;
	Vector3 velocity;
    public float jumpSpeed = 200f;
    private bool m_canJump;
    public float x_speed;
    public float z_speed;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //prend les composant du rigidBody du joueur et les mets dans rb
        rb.freezeRotation = true; // empêche le cube de tourne
        m_canJump = false;
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

        //permet de savoir si un joueur peut re-sauter
        if (m_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpSpeed, 0);// addForce donne un coup vers une position
            m_canJump = false;
        }
        rb.velocity = transform.TransformDirection(velocity);

        if(transform.position.y <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
    //fonction qui définit se qui se passe lors d'une collision
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            m_canJump = true;
        }
        if(collision.gameObject.tag == "Danger")
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
