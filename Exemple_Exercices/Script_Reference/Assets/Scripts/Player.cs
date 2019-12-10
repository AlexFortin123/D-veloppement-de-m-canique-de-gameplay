using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameplayManager m_GameplayManager;
    public GameObject m_Ammo_Prefab;

    //public GameObject m_Player;
    public Player m_Player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ammoGo = GameObject.Instantiate(m_Ammo_Prefab, transform.position + (Vector3.up * 5f), Quaternion.identity);
            Ammo ammo = ammoGo.GetComponent<Ammo>();
            ammo.m_Player = this;
        }
    }

    public void CheckDeath()
    {
        Debug.Log("CheckDeath");
    }
}
