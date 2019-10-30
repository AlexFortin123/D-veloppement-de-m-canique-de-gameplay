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

    private Vector3 m_StartingPos;
    private int index;
    private float m_Pourcentage;
    private GameObject m_zone;
    private DetectionzoneController m_DetecteZone;
    private float timer;

    private void Awake()
    {
        index = 1;
        m_Pourcentage = 0f;
        m_StartingPos = transform.position;
        m_zone = GameObject.Instantiate(m_DetectZonePlayer, gameObject.transform.position, Quaternion.identity);
        m_zone.transform.SetParent(this.transform);
        m_DetecteZone = m_zone.GetComponent<DetectionzoneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_DetecteZone.m_ObjectDetected)
        {
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
        else
        {
            Debug.Log(m_DetecteZone.transform.position);
            timer += Time.deltaTime;
            if(timer > m_WaitingTimeShoot)
            {
                GameObject projectileGameObject = GameObject.Instantiate(m_balleEnnemy, transform.position + 2f * Vector3.forward, Quaternion.identity);
                projectileGameObject.transform.rotation = transform.rotation;
                projectileGameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_DetecteZone.transform.position - transform.position),
                    3f * Time.deltaTime);
                timer = 0;
            }
            transform.position += transform.forward * Time.deltaTime;
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
   
}
