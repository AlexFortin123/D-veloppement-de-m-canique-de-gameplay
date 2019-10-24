using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    //une fonction
    /* void TestFonction()
     {

     }*/

    //IEnumerator est le mot clé qui permet d'appeler une coroutine, a besoin d'un yiel return
    //Pour commencer une Coroutine dans un code il faut faire : StartCoroutine("TestCoroutine");
    //la coroutine va exécuter le code après une frame quand il rencontre un yield
    IEnumerable TestCoroutine()
    {
        yield return null;// attend un frame
        yield return new WaitForSeconds(5f);//attend 5 secondes
    }
}
