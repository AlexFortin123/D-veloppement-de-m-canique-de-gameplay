using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_ObjectToSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball_GO = GameObject.Instantiate(m_ObjectToSpawn, Vector3.up * 2f, Quaternion.identity);

            Ball maBalle = ball_GO.GetComponent<Ball>();

            if(maBalle != null)
            {
                maBalle.Jump(transform.position.x);

                maBalle.m_MaVariableDeCompteur = 0;
            }
        }
    }
}
