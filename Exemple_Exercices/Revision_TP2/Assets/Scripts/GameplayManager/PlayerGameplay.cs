using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameplay : MonoBehaviour
{
    public GameplayManager m_GamePlayManager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Ramasser une cenne
            m_GamePlayManager.AddCoins(1);
        }
    }
}