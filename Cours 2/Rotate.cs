using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    public Vector3 m_RotateAxe = Vector3.up;
	public float m_RotateSpeed = 0f;
    public bool m_ReverseRotation = false;

   // private Vector3 m_InitialRotation;

    private void Start()
    {
       // m_InitialRotation = transform.localRotation.eulerAngles;
    }

    private void Update () 
	{
		if(m_ReverseRotation)
		{
            m_RotateSpeed = -m_RotateSpeed;
            m_ReverseRotation = false;

            //Debug.Log("Changing Side");
		}

        transform.Rotate(m_RotateAxe, m_RotateSpeed);

       /* if (Input.GetKeyDown(KeyCode.R))
        {
            ResetRotation();
        }*/

        //Debug.DrawLine(transform.position, transform.position + m_RotateAxe, Color.magenta);

        // Ne pas oublier d'enlever le if(m_ReverseRotation) si on y vas avec rotateSide
        //float rotateSide;
        /*if (m_ReverseRotation == true) // if(m_ReverseRotation)
        {
            rotateSide = -1f;
        }
        else
        {
            rotateSide = 1f;
        }*/
        //rotateSide = m_ReverseRotation ? -1f : 1f;
        //transform.Rotate(m_RotateAxe, m_RotateSpeed * rotateSide * Time.deltaTime);
    }

    /*private void ResetRotation()
    {
        transform.localRotation = Quaternion.Euler(m_InitialRotation);

        Debug.Log("Reset Rotation");
    }*/
}