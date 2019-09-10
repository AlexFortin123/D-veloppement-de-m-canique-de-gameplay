using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // faire monter le plane pour faire un ascenseur
    void Monter()
    {
        Vector3 pos;
        if(transform.position.y < 20)
        {
            pos = transform.position;
            pos.y += 1;
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Monter();
    }
}
