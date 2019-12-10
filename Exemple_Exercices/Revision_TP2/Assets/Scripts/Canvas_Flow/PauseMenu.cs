using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame(bool i_Pause)
    {
        // https://docs.unity3d.com/ScriptReference/Time-timeScale.html

        Time.timeScale = i_Pause ? 0f : 1f; // Version Ternaire du code en dessous 
        if (i_Pause)
        {
            // Visuel de PauseMenu Activé
            Time.timeScale = 0f;
        }
        else
        {
            // Visuel de PauseMenu Désactivé
            Time.timeScale = 1f;
        }
    }
}