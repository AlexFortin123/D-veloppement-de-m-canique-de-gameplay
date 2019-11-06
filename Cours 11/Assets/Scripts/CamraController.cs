using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraController : MonoBehaviour
{
    public GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * La caméra block sur les bords de la map avec des Raycast
         * Créer un layer Boundary
         * Créer des variables public Transform pour les murs
         * Vector3 newPos = m_Player.transform.position;
         * if(Physics.RayCast(m_Left.transform.position, m_Left.forward, 0.5f, LayerMask("Boundary")))
         * {
         *      newPos.x = transform.position.x;
         * }
         * transform.position = newPos;
         * */
    }
}
