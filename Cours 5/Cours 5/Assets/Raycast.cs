using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Physics.Raycast();//on peut l'écrire autant de fois qu'on veut avec des paramètres différents 16 fois
        // if(hit == NULL) n'a pas de collider
        // if(hit != NULL) a un collider
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, new Vector3(0f, -1f, 0f), Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 1f))
        {
            Debug.Log("j'ai toucher un objet");
        }
        else
        {
            Debug.Log("nope");
        }
    }
}
