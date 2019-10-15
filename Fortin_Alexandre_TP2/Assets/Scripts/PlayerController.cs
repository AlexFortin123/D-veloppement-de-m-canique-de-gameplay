using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerController : MonoBehaviour
    {

    public UnityEngine.Camera m_Camera;
    public UnityEngine.AI.NavMeshAgent m_NavMeshAgent;
    // Start is called before the first frame update
    void Awake()
    {
        //Animator - GetComponent<Animator>();
        m_NavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {

                m_NavMeshAgent.SetDestination(hit.point);
            }
                   
        }
    }
}