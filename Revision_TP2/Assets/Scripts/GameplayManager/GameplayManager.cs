using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public HudWindow m_HudWindow;
    private int m_Coins;

    public void AddCoins(int i_Coins)
    {
        m_Coins += i_Coins;
        m_HudWindow.RefreshScore(m_Coins);
    }
}