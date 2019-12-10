using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour 
{
	public Rigidbody m_Rigidbody;
	public float m_MoveSpeed = 0f;

    private Vector3 m_MoveDir;
    private Vector3 m_Velocity;

    private void Awake()
    {
        m_MoveDir = new Vector3();
        m_Velocity = new Vector3();
    }

    public void Update () 
	{
		if(Input.GetKey(KeyCode.Space))
		{
            m_MoveDir = transform.forward;
		}
		else
		{
			m_MoveDir = Vector3.zero;
		}

        m_Velocity = m_MoveDir * m_MoveSpeed;
	}
	
	public void FixedUpdate()
	{
        //m_Rigidbody.velocity = m_Velocity; // mètre / sec.
        transform.Translate(m_Velocity);

       // Debug.Log(Time.fixedDeltaTime); // ProjectSettings -> Time -> Fixed step
    }
}
