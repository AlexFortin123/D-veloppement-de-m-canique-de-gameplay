using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_Balle;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject balle_GO = GameObject.Instantiate(m_Balle);
            Balle balle = balle_GO.GetComponent<Balle>();
            balle.Shoot(transform.forward, 10f, 20);
        }
    }
}
