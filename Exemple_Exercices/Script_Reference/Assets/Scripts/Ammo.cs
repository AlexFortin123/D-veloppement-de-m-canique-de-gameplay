using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //public GameObject m_Player;
    public Player m_Player;
    
    void Update()
    {
        //m_Player.gameObject;
        //m_Player.transform;
        m_Player.CheckDeath();
    }
}
