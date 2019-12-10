using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExemple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Physics.Raycast(  );
        //Physics.Raycast();


        //if(hit == null)

        //Vector3.up; // new Vector3(0f, 1f, 0f);
        //Vector3.up * -1f; // new Vector3(0f, -1f, 0f);

        
        //if(hit == null) // Mon raycast a pas collider
        //if(hit != null) // Mon raycast a collider

        //Vector3 v; // v == null
        //Vector3 move = new Vector3(); // move = x = 0f, y =0f, z=0f
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        Debug.DrawRay(transform.position, new Vector3(0f, -100f, 0f), Color.red);
        //Debug.DrawLine();
        RaycastHit hit; // hit == null
        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 100f))
        {
            Debug.Log(hit.distance);
            //Debug.Log("J'Ai toucher un objet");
        }
        else
        {
            Debug.Log("Nope");
        }
    }
}
