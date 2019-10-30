using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject m_ControlContainer;
    public GameObject m_PlayerContainer;

    public void LoadGamePlay()
    {
        SceneManager.LoadScene("Mathematiques");
    }

    public void ShowControl()
    {
        m_ControlContainer.SetActive(true);
        m_PlayerContainer.SetActive(false);
    }

    public void ShowPlay()
    {
        m_ControlContainer.SetActive(false);
        m_PlayerContainer.SetActive(true);
    }
}
