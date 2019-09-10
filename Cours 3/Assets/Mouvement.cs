using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector3 newVelocity;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            newVelocity.z = speed;
        }
        else
        {
            newVelocity.z = 0;
        }
       

    }
    private void FixedUpdate()
    {
        rigidBody.velocity = newVelocity;
    }
}
