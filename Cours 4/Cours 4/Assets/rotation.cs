using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    Vector3 newRotation = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newRotation = transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.A))
        {
            newRotation.z = newRotation.z + 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newRotation.z = newRotation.z - 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newRotation.y = newRotation.y + 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newRotation.y = newRotation.y - 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newRotation.x = newRotation.x + 1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newRotation.x = newRotation.x - 1f;
        }
        transform.rotation = Quaternion.Euler(newRotation);
        /*newRotation = transform.rotation.eulerAngles;
        newRotation.y = newRotation.y + 1f;
        //newRotation.x = newRotation.x + 1f;
        newRotation.z = newRotation.z + 1f;
        transform.rotation = Quaternion.Euler(newRotation);*/
    }
}
