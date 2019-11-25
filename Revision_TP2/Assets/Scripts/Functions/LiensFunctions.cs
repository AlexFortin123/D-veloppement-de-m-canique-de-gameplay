using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiensFunctions : MonoBehaviour
{
    public RevisionFunctions m_RevisionFunction;
    
    void Start()
    {
        // Pas accèes a une fonction privée
        //m_RevisionFunction.MaFonction();

        m_RevisionFunction.MaFonctionPublique();
    }
}