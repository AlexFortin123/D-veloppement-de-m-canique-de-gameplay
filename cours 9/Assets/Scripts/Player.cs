using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_Balle_Prefad;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InstatiationBallFunction(m_Balle_Prefad);
        }
    }
    private void InstatiationBallFunction(GameObject balle)
    {
        //Avec la rotation d'un object, on le enfant pour qu'il garde sa direction
        GameObject ballGo = GameObject.Instantiate(balle, transform.position, Quaternion.identity);

        Balle ball = ballGo.GetComponent<Balle>();
        ball.m_Player = this;
    }
}
