using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script qui défini le comportement d'un levier (cube jaune), si elle est touché par le joueur, le levier fait descendre la porte 
 * qui est rattacher au levier
 */
public class LevierController : MonoBehaviour
{
    public GameObject m_Porte;
    
    private void OnTriggerEnter(Collider other)
    {
        //si le joueur rentre en collision avec le levier, il active la coroutine qui permet de faire descendre la porte
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("CloseDoor");
            this.GetComponent<Renderer>().material.color = Color.green;
            Destroy(gameObject.GetComponent<BoxCollider>());

        }
    }

    //Coroutine qui fait descendre la porte puis après un certain la détruit
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
