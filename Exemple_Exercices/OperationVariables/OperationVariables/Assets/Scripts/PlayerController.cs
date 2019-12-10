using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 move = new Vector3();

    float x = 0f;
    float y = 0f;
    float z = 0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //move.x = -5f;
            //x = -5f;

            x -= 0.025f;

            if(x <= -1f)
            {
                x = -1f;
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //move.x = 5f;
            //x = 5f;
            x += 0.025f;

            if(x >= 1f)
            {
                x = 1f;
            }
        }
        else
        {
            //move.x = 0f;
            //x = 0f;

            x *= 0.9f; 

            if(x >= -0.1f && x <= 0.1f)
            {
                x = 0f;
            }
        }

        transform.Translate(x, y, z);
        Debug.Log(x);
        //transform.Translate(move);
    }
}

