using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject m_Player_Prefab;
    private Player m_Player;
   
    // Start is called before the first frame update
    void Start()
    {
        // Cette ligne est l'équivalent des 3 lignes en dessous.
        //GameObject.Instantiate(m_Player_Prefab).GetComponent<Player>().m_GameplayManager = this;

        GameObject playerGO = GameObject.Instantiate(m_Player_Prefab);
        Player player = playerGO.GetComponent<Player>();

        if (player != null)
        {
            player.m_GameplayManager = this;
            m_Player = player;
        }

        GameObject.Instantiate(playerGO);
    }
}