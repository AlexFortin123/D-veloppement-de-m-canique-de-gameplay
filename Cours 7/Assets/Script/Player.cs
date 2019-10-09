using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_TraingleToSpawn;
    public GameObject m_ObjectToSpawn;
    public Rigidbody rb;
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball_Go = GameObject.Instantiate(m_ObjectToSpawn, transform.position + Vector3.up * 2f, Quaternion.identity);
            Ball maBall = ball_Go.GetComponent<Ball>();

            if (maBall != null)
            {
                maBall.SetPlayer(gameObject);// donne le joueur a la ball, car si l'objet n'existe pas dans la scene, il faut passer la référence
                //de l'objet pour qu'il puisse savoir de quel objet il a besoin d'avoir les données
                maBall.jump(transform.position.x);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {

            x -= 0.05f;//augmente la vitesse en x neg

            if (x <= -3f)//pour éviter qu'il accélère a l'infinie
            {
                x = -1f;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x += 0.05f;//augmente la vitesse en x pos

            if (x >= 3f)
            {
                x = 0.5f;
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

            z += 0.05f;//augmente la vitesse en z neg

            if (z <= 3f)//pour éviter qu'il accélère a l'infinie
            {
                z = 1f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            z -= 0.05f;//augmente la vitesse en z pos

            if (z >= -3f)
            {
                z = -0.5f;
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
        transform.Translate(x, y, z);

    }
}
