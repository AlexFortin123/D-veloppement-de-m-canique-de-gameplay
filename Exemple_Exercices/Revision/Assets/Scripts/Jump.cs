using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody m_RigidBody;
    // On la met public si on veut pouvoir changer la valeur dans l'editor
    //public Vector3 m_JumpVector = new Vector3();
    // On a une variable de force fixe qui ne peux pas être changer dans l'editor
    Vector3 m_Force = new Vector3(0f, 250f, 0f);

    // Une booleen pour géré l'état de mon personnage a savoir si oui ou non il touche au sol.
    private bool m_IsOnGround;

    void Update()
    {
        // Input.GetKeyDown est == true, seulement le premier frame que j'appuie sur la touche.
        // Input.GetKey est == true a tout les frame que j'appuie sur la touche
        // Je vérifie que ma boolean m_IsOnGround est a true, donc si je touche au sol.
        if(m_IsOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            // On passe une force en Vector3, donc une force en 3 direction a notre rigidbody.
            // La force va être appliquer automatiquement a la velocité de notre rigidbody
            m_RigidBody.AddForce(m_Force);
        }

        RaycastHit hit;
        // Vector3.up == new Vector3(0f, 1f, 0f);
        // -Vector3.up == new Vector3(0f, -1f, 0f);
        // Si Mon raycast est vrai, mon raycast a toucher un collider, si mon raycast est faux, mon raycast n'a pas toucher de collider

        //Vector3 v1 = new Vector3(0f, 1f, 0f);
        //Vector3 v2 = new Vector3(1f, 0f, 1f);
        //Vector3 v3 = v1 + v2; // v3.x = v1.x + v2.x. // v3.y = v1.y + v2.y

        //On décale le raycast de 0.1f en y pour que le raycast soit lancer un peu plus haut que la collision de la plateforme.
        if(Physics.Raycast(transform.position + new Vector3(0f, 0.1f, 0f), -Vector3.up, out hit, 0.2f))
        {
            // J'AI TOUCHER UN COLLIDER
            m_IsOnGround = true;
            Debug.Log("Touche");
        }
        else
        {
            // J'AI PAS TOUCHER DE COLLIDER
            m_IsOnGround = false;
            Debug.Log("Touche pas");
        }

        // Je draw un ray qui sera visible dans la fenetre scene seulement
        // Un point de départ, un direction multiplier par la longueur du raycast, une couleur.
        Debug.DrawRay(transform.position + new Vector3(0f, 0.1f, 0f), -Vector3.up * 0.2f, Color.black);
    }
}