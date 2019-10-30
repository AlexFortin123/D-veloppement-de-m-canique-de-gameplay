using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject m_Ammo_Prefab;
    public Transform m_Target;

    private bool m_HasTarget;

    public Text m_ScoreTxt;

    private int m_Score;

    private void Start()
    {
        m_Score = 0;

        m_ScoreTxt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject ammo_GameObject = GameObject.Instantiate(m_Ammo_Prefab, transform.position, Quaternion.identity);
            Ammo monAmmo = ammo_GameObject.GetComponent<Ammo>();

            Vector3 direction = m_Target.position - transform.position;
            direction.Normalize();

            monAmmo.m_Direction = direction;

            m_Score++;
            m_ScoreTxt.text = m_Score.ToString();
        }
    }
}
