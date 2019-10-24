using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisController : MonoBehaviour
{
    public int m_Hp;
    public List<GameObject> m_NoeudPartrouille;
    private Vector3 m_StartingPos;
    public float m_Speed;
    private int index;
    private float m_Pourcentage;
    
    private void Awake()
    {
        index = 1;
        m_Pourcentage = 0f;
        m_StartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(m_StartingPos, m_NoeudPartrouille[index].transform.position, m_Pourcentage);
        if(m_Pourcentage >= 1)
        {
            index++;
            m_Pourcentage = 0;
            m_StartingPos = transform.position;
        }
        if(index >= m_NoeudPartrouille.Count)
        {
            index = 0;
        }
        m_Pourcentage += m_Speed * Time.deltaTime;
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
