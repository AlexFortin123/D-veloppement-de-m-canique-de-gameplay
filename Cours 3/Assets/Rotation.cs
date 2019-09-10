using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    Rigidbody oRigidBody;
    Vector3 newRotation;
    public float angle = 60f;
    // Start is called before the first frame update
    void Start()
    {
        oRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.up, angle* Time.deltaTime);
        }
    }
}
