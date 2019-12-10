using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleCoroutine : MonoBehaviour
{
    private int m_Ammo;

    private bool m_Reload;
    private float m_ReloadTime;

    void Start()
    {
        m_Ammo = 5;
        //TestFonction();
       // StartCoroutine("TestCoroutine");
    }

    // Une Fonction
    void TestFonction()
    {
        Debug.Log("Ma Fonction");

        for (int i = 0; i < 250; i++)
        {
            Debug.Log("Fonction For");
        }

        Debug.Log("Frame 101 Fonction");
    }

    private void Update()
    {
        if(m_Ammo > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            m_Ammo--;
            Debug.Log(m_Ammo);
            if(m_Ammo <= 0)
            {
                StartCoroutine("Reload");
                m_Reload = true;
                m_ReloadTime = 5f;
            }
        }

        // Équivalent de la coroutine Reload mais avec l'update et 2 variables simple (boolean et compteur)
        if(m_Reload)
        {
            m_ReloadTime -= Time.deltaTime;
            if(m_ReloadTime <= 0f)
            {
                m_Reload = false;
                m_Ammo = 5;
            }
        }
    }

    // Coroutine Test
    IEnumerator Reload()
    {
        Debug.Log("Starting Reload");
        yield return new WaitForSeconds(5f);

        Debug.Log("Reload Finish");

        m_Ammo = 5;
    }

    // Une Coroutine
    IEnumerator TestCoroutine()
    {
        Debug.Log("Mon Premier Log de Coroutine");

        yield return new WaitForSeconds(5f);

        Debug.Log("Frame 1");

        for(int i = 0; i < 250; i++)
        {
            yield return null;
        }
        
        Debug.Log("Frame 101");

        yield return null;
    }
}
