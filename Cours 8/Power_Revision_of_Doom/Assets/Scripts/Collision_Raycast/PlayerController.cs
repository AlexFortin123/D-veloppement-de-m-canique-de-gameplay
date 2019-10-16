using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody m_RigidBody;

    // On Collision Enter va nous retourner en paramètre le component de collision, de l'objet avec lequel je suis entré en collision
    private void OnCollisionEnter(Collision collision)
    { 
        //Debug.Log("Enter" + collision.gameObject.name);
    }

    // On Collision Stay va nous retourner en paramètre le component de collision a tout les frames que je vais toucher a cette collision
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("Stay " + collision.gameObject.name);
    }

    // On Collision Exit va nous retourner en paramètre le component de collision, de l'objet avec lequel j'ai quitté la collision
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Exit " + collision.gameObject.name);
    }

    // On Trigger Enter va nous retourner en paramètre le component de collider, de l'objet avec lequel je suis entré en collision.
    // Par contre un trigger n'est pas présent physiquement dans l'environnement, donc le joueur ne sera pas bloqué par sa collision.
    private void OnTriggerEnter(Collider other)
    {
        // On peut vérifier le tag du collider en demandant au gameObject de celui-ci, avec other.gameObject.tag
        if (other.gameObject.tag == "Blue")
        {
            Debug.Log("Blue Coins");
        }
        else if(other.gameObject.tag == "Red")
        {
            Debug.Log("Red Coins");
        }
    }

    private void Update()
    {

        RaycastHit hit;
        Vector3 origine = transform.position + new Vector3(0f, 0.1f, 0f);
        // Un raycast est un laser qu'on envois dans l'univers, a partir d'un point d'origine, on L,envois dans une direction, avec une distance maximal
        // Si le raycast est vraie, ca veut dire, qu'une collision a été detecter par le raycast.
        if (Physics.Raycast(origine, -Vector3.up, out hit, 0.2f, LayerMask.GetMask("BlueCoins","RedCoins","Plateforme")))
        {
            Debug.Log("Mon Raycast a toucher a quelqueChose");

            // Si C'est vrai, on obtiens l'information de la collision dans hit
            //hit.distance;
            //hit.point;
            //hit.collider;
        }
        else
        {
            Debug.Log("Mon Raycast n'a toucher a rien.");
        }

        // Draw Ray va être notre représentation visuel de notre raycast dans le "SCENE VIEW"
        Debug.DrawRay(origine, -Vector3.up * 0.2f, Color.red);
    }
}
