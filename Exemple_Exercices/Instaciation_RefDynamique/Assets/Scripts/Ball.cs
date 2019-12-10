using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public int m_MaVariableDeCompteur;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump(float i_PlayerPositionX)
    {
        Vector3 force = new Vector3(i_PlayerPositionX, 1f, 0f);
        m_Rigidbody.AddForce(force * 200f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
