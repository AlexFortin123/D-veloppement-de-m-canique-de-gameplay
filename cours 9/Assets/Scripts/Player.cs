using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_Balle_Prefad;
    private int m_ammo;
    // Start is called before the first frame update
    private void Awake()
    {
        m_ammo = 2;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InstatiationBallFunction(m_Balle_Prefad);
        }
    }
    private void InstatiationBallFunction(GameObject balle)
    {
        if(m_ammo > 0)
        {
            //Avec la rotation d'un object, on le enfant pour qu'il garde sa direction
            GameObject ballGo = GameObject.Instantiate(balle, transform.position, Quaternion.identity);

            Balle ball = ballGo.GetComponent<Balle>();
            ball.m_Player = this;
            m_ammo--;
            if (m_ammo == 0)
            {
                Debug.Log("Je dois recharger");
                StartCoroutine("ShootDelay");
            }
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(5f);
        m_ammo = 2;
    }
}
