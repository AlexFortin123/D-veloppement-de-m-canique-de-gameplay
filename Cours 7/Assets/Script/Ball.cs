using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private GameObject joueur;

    //public int m_MaVariableDeCompteur;
    // Start is called before the first frame update
    public void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }
    public void SetPlayer(GameObject playerObject)
    {
        joueur = playerObject;
    }
    public void jump(float i_playerPositionX)
    {
        Vector3 force = new Vector3(i_playerPositionX, 1f, 0f);
        m_RigidBody.AddForce(force * 200f);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);//gameobject appeler comme ca est la référence de l'objet dont le srcipt est attaché
        }
        if((joueur.transform.position - transform.position).magnitude > 60f)
        {
            Destroy(gameObject);
        }
    }
}
