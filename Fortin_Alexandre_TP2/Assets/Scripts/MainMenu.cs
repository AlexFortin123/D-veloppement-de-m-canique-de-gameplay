using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Script qui fait la gestion du main menu et ouvre la scene MainGame aund on appui sur start ou qui eprmet de quitter
 * l'application quand on click sur le boutton click
 */

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Bye");
        Application.Quit();
    }
}
