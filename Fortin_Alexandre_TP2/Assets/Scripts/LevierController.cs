using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevierController : MonoBehaviour
{
    public GameObject m_Porte;
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("CloseDoor");
            this.GetComponent<Renderer>().material.color = Color.green;
            Destroy(gameObject.GetComponent<BoxCollider>());

        }
    }

    IEnumerator CloseDoor()
    {
        while(m_Porte.transform.position.y > -5f)
        {
            m_Porte.transform.Translate(Vector3.down * Time.deltaTime);
            yield return null;
        }
        Destroy(m_Porte);
        yield return null;
    }
}
