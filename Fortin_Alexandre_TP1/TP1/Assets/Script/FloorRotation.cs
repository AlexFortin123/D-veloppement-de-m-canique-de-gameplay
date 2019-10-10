using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotation : MonoBehaviour
{
    Vector3 newRotationPos;
    public float speedRotationZ;
    // Start is called before the first frame update
    void Start()
    {
        newRotationPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        newRotationPos = transform.eulerAngles;
        newRotationPos.z += speedRotationZ;
        transform.eulerAngles = newRotationPos;
    }
}
