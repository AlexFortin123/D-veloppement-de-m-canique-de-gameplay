using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisController : MonoBehaviour
{
    public int m_Hp;
    public List<GameObject> m_NoeudPartrouille;
    public GameObject m_DetectZonePlayer;
    public float m_Speed;
    public GameObject m_balleEnnemy;
    public int m_WaitingTimeShoot;
    public bool m_PlayerDetected;
    public bool m_CanMove;

    private Vector3 m_StartingPos;
    private float m_Distance;
    private int index;
    private float m_Pourcentage;
    private float timer;
    private Transform m_TransformTarget;
    
    


    private void Awake()
    {
        index = 1;
        m_Pourcentage = 0f;
        m_StartingPos = transform.position;
        m_PlayerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_PlayerDetected)
        {
            if(m_NoeudPartrouille.Count != 0)
            {
                //m_Distance = Vector3.Distance(transform.position, m_NoeudPartrouille[index].transform.position);
                transform.position = Vector3.Lerp(m_StartingPos, m_NoeudPartrouille[index].transform.position, m_Pourcentage);
                if (m_Pourcentage >= 1)
                {
                    index++;
                    m_Pourcentage = 0;
                    m_StartingPos = transform.position;
                }
                if (index >= m_NoeudPartrouille.Count)
                {
                    index = 0;
                }
                m_Pourcentage += m_Speed * Time.deltaTime; //Permet de rendre constant le pourcentage
            }
            
        }
        else
        {
            timer += Time.deltaTime;
            transform.LookAt(m_TransformTarget);
            if (timer > m_WaitingTimeShoot)
            {
                GameObject projectileGameObject = GameObject.Instantiate(m_balleEnnemy, transform.position  + Vector3.forward, Quaternion.identity);
                projectileGameObject.transform.rotation = transform.rotation;
                projectileGameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                timer = 0;
            }
            if(m_CanMove)
            {
                float distance = Vector3.Distance(m_StartingPos, m_TransformTarget.position);
                transform.position = Vector3.Lerp(m_StartingPos, m_TransformTarget.position, m_Pourcentage / distance);
                if (m_Pourcentage >= 1)
                {
                    index++;
                    m_Pourcentage = 0;
                    m_StartingPos = transform.position;
                }
                if (index >= m_NoeudPartrouille.Count)
                {
                    index = 0;
                }
                m_Pourcentage += m_Speed * Time.deltaTime; //Permet de rendre constant le pourcentage
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            m_Hp--;
            if(m_Hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
    //
    public void ManageTargetTransform(Transform aTransformTarget)
    {
        m_TransformTarget = aTransformTarget;
    }

}
