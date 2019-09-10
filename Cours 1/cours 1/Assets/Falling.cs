using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public int New_y;
    public Rigidbody new_body;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Fall()
    {
        Vector3 pos;
        if (transform.position.y < 0.4)
        {
            pos = transform.position;
            pos.y = New_y;
            transform.position = pos;

            new_body.velocity = Vector3.zero;
            //new_body.velocity *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
    }
}
