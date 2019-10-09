using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
   // Vector3 move = new Vector3();
    float x = 0f;
    float y = 0f;
    float z = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //x = -5f; ou

            x -= 0.025f;//augmente la vitesse en x neg

            if(x <= -3f)//pour éviter qu'il accélère a l'infinie
            {
                x = -1f;
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //x = 5f; ou
            x += 0.025f;//augmente la vitesse en x pos

            if (x >= 3f)
            {
                x = 1f;
            }
        }
        else
        {
            //décélération : multiplier par une variable inférieur a 1
            x *= 0.95f;
            //pour éviter que la division se fasse a l'infinie
            if (x >= -0.1f && x <= 0.1)
            {
                x = 0f;
            }

        }
        if (Input.GetKey(KeyCode.W))
        {
            //x = -5f; ou

            z -= 0.025f;//augmente la vitesse en z neg

            if (z <= -3f)//pour éviter qu'il accélère a l'infinie
            {
                z = -1f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //x = 5f; ou
            z += 0.025f;//augmente la vitesse en z pos

            if (z >= 3f)
            {
                z = 1f;
            }
        }
        else
        {
            //décélération : multiplier par une variable inférieur a 1
            z *= 0.95f;
            //pour éviter que la division se fasse a l'infinie
            if (z >= -0.1f && z <= 0.1)
            {
                z = 0f;
            }

        }
        transform.Translate(x,y,z);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 1000f, Color.blue);//dessine un raycast dans unity
        if(Physics.Raycast(transform.position, Vector3.down, out hit, LayerMask.GetMask("Floor", "LavaFloor")))//que fait l'objet quand il collision avec des objet avec des layers
        {
            Debug.Log(hit.collider.gameObject.tag);
        }
        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        //colision = box collider
        Debug.Log(collision.gameObject.name);//affiche le nom de l'objet avec lequel il entre en collision
        Debug.Log(collision.gameObject.tag);//affiche le nom du tag de l'objet avec lequel il entre en collision

        if(collision.gameObject.tag == "Lava")
        {
            //mon player il meurt
        }
        if(collision.gameObject.tag == "Ground")
        {
            //tu peut sauter
        }
    }*/
    //on peut aller dans project setting / physics pour dire quel layer va interagir avec d'autre ou pas

    //un objet rentre dans un trigger, il faut que le box collider a la cose IsTrigger cocher, mais l'objet passe au travers de l'autre
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
    }
}
