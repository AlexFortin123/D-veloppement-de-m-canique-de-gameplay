using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleList : MonoBehaviour
{
    private Vector3 m_Vector3;

    private List<int> m_AllScore;
    private List<int> m_AllScoreCopy;

    private void Start()
    {
        // Déclaration d'une liste vide
        m_AllScoreCopy = new List<int>();
        m_AllScoreCopy.Add(1);
        m_AllScoreCopy.Add(10);

        // Déclaration d'une liste vide
        m_AllScore = new List<int>();
        // Déclaration d'une liste avec une capacité donnée
        m_AllScore = new List<int>(5);
        // Déclaration d'une liste qui va etre une copy de celui donner en paramètre
        m_AllScore = new List<int>(m_AllScoreCopy);

        // Call fonction
        AddScore(10);
    }

    public void AddScore(int i_Score)
    {
        // Rajouter un element a la fin d'une liste
        m_AllScore.Add(i_Score);

        // Enlever un element donner, il va enlever la première occurence de celui ci
        m_AllScore.Remove(i_Score);

        // Rajouter un element a l'index donner de la liste
        m_AllScore.Insert(0, i_Score);

        // Enlever un element a un index donner
        m_AllScore.RemoveAt(0);

        // Rajouter un element a la fin d'une liste
        m_AllScore.Add(i_Score);

        Debug.Log(m_AllScore.Count);

        // Enlever tout les elements d'une liste
        m_AllScore.Clear();

        Debug.Log(m_AllScore.Count);

        /*[];
        m_AllScore.Add(1);
        [ 1 ];
        m_AllScore.Add(2);
        [ 1 , 2 ];
        m_AllScore.Add(3);
        [ 1 , 2 , 3 ];
        m_AllScore.Add(4);
        [ 1 , 2 , 3 , 4];*/

        int monScoreIndex0 = m_AllScore[0]; // moNScoreIndex0 sera égale a 1
        int monScoreIndex2 = m_AllScore[2]; // monScoreIndex2 sera égale a 3
        //int monScoreIndex4 = m_AllScore[4]; // monScoreIndex4 sera égale a Error OutOfRange

    }
}
