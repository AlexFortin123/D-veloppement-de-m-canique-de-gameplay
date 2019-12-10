using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Variable complexe de rigidBody, le liens est fait dans l'editeur sur le player.
    public Rigidbody m_RigidBody;
    // Vector3 qui contient l'information de la velocity que je veux donner au joueur.
    Vector3 m_Velocity = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // On récupère la velocité de notre rigidbody, afin de ne pas perdre la gravité qui pousse sur notre objet
        m_Velocity = m_RigidBody.velocity;


        // Si j'appuie sur la touche A
        if(Input.GetKey(KeyCode.A))
        {
            // La valeur en X de mon vector de donnée est égale a -5f;
            m_Velocity.x = -5f;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            m_Velocity.x = 5f;
        }
        else
        {
            m_Velocity.x = 0f;
        }
    }

    private void FixedUpdate()
    {
        // La velocité du rigidbody est égale a la velocité que j'ai stocker dans la variable m_Velocity
        m_RigidBody.velocity = m_Velocity;
    }
}
