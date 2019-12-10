using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera m_MaCamera;
    public GameObject m_SpherePrefab;
    // Update is called once per frame
    void Update()
    {
        // 0 = click gauche
        // 1 = click droit
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("J'ai cliquer");

            Ray ray = m_MaCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("J'ai toucher un collider");

                Debug.Log(hit.point);

                GameObject.Instantiate(m_SpherePrefab, hit.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("Rien");
            }
        }
    }
}
