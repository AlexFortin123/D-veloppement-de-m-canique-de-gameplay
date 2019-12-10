using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1000f, Color.blue);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1000f, LayerMask.GetMask("Floor" , "LavaFloor")))
        {
           // Debug.Log("Je Touche a Quelque chose");

           Debug.Log(hit.collider.gameObject.tag);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // collision = Box Collider qui est attacher a notre Ground
        //Debug.Log("Collision");
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.tag);

        if(collision.gameObject.tag == "Lava")
        {
            // Mon Player Die
        }

        if(collision.gameObject.tag == "Ground")
        {
            // Tu peux sauter
        }
    }
}
