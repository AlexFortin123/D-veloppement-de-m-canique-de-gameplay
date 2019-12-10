using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody m_RididBody;

    private bool m_IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            m_RididBody.AddForce(new Vector3(0f, 200f, 0f));
        }

        RaycastHit hit;

        Vector3 raycastOrigin = transform.position;
        raycastOrigin.y += 0.1f;

        Debug.DrawRay(raycastOrigin + new Vector3(0.5f, 0f, 0f), Vector3.down * 0.2f, Color.black);
        bool rayCastRight = Physics.Raycast(raycastOrigin + new Vector3(0.5f, 0f, 0f), Vector3.down, out hit, 0.2f);
        Debug.DrawRay(raycastOrigin, Vector3.down * 0.2f, Color.blue);
        bool rayCastMiddle = Physics.Raycast(raycastOrigin, Vector3.down, out hit, 0.2f);
        Debug.DrawRay(raycastOrigin - new Vector3(0.5f, 0f, 0f), Vector3.down * 0.2f, Color.red);
        bool rayCastLeft = Physics.Raycast(raycastOrigin - new Vector3(0.5f, 0f, 0f), Vector3.down, out hit, 0.2f);

        if (rayCastLeft || rayCastMiddle || rayCastRight)
        {
            m_IsGrounded = true;
        }
        else
        {
            m_IsGrounded = false;
        }
    }
}
