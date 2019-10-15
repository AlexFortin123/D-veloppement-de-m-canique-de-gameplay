using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurPointToclick : MonoBehaviour
{
    public Camera m_camera;
    //public GameObject m_Prefad;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//0 = click gauche, 1 click droit, 2 click du milieu
        {
           Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);//donne la direction et l'origine du rayCast
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 newTargetGetPos = hit.point;
                agent.SetDestination(newTargetGetPos);
            }
        }
    }
}
