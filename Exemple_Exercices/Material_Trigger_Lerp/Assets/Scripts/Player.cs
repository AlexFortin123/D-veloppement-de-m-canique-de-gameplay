using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Debug.Log(Vector3.up);
        Debug.Log(transform.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionEnter");

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");

        //Destroy(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerStay");
    }
}
