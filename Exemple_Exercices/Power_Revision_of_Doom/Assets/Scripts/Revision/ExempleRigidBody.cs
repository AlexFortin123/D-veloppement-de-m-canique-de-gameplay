using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleRigidBody : MonoBehaviour
{
    public Rigidbody m_MonRigidBody;

    private Vector3 m_MaVelocity;

    private Vector3 m_MaForce;

    // Start is called before the first frame update
    void Start()
    {
        m_MaVelocity = new Vector3(1f, 0f, 0f);

        // La valeur qu'on passe a la velocity de notre RigidBody est en m/s
        m_MonRigidBody.velocity = m_MaVelocity;

        m_MaForce = new Vector3(0f, 200f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            // AddForce est une pousser que l'ont attribut avec un Vector3 de force, pour donner une direction et une force de poussé.
            m_MonRigidBody.AddForce(m_MaForce);
        }
    }
}
