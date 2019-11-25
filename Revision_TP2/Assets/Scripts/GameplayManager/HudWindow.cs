using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudWindow : MonoBehaviour
{
    public Text m_ScoreText;

    public void RefreshScore(int i_Score)
    {
        m_ScoreText.text = i_Score.ToString();
    }
}
