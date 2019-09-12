﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
    public float turnSpeed = 10f;
	Vector3 velocity;
    public float jumpSpeed = 200f;
    private bool m_canJump;
    public float x_speed;
    public float z_speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //prend les composant du rigidBody du joueur et les mets dans rb
        rb.freezeRotation = true; // empêche le cube de tourne
        m_canJump = false; 

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

        //mouvement du joueur en z
        /*if (Input.GetKey(KeyCode.W))
        {
            velocity.z = z_speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.z = -z_speed;
        }
        else
        {
            velocity.z = 0f;
        }*/

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
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_canJump = true;
    }
}
