using UnityEngine;

public class Coding : MonoBehaviour
{
    private bool m_MaBoolean; // Variable qui peut contenir 2 valeur seulement, True, false. Donc on se sert de la boolean pour des if condition ou pour stocker un state.
    private int m_MonInt; // Variable qui peut contenir un chiffre ou un nombres, mais aucun point a virgule. 
    private float m_MonFloat; // Variable qui peut contenir un chiffre ou un nombres, awvec une précision de point virgule.

    void Start()
    {
        m_MonFloat = m_MonFloat + 2f; // Rajouter 2f a la valeur de m_MonFloat
        m_MonFloat += 2f; // Exactement pareil que la ligne au dessus, mais plus optimal et plus souvent utilisé

        m_MonFloat -= 2f; // Quand on utilise des valeur en float, on veut mettre un f a la fin du nombres, pour spécifier au compilateur qu'il s'agit d'un point flotant a virgule
        m_MonFloat *= 2f;
        m_MonFloat /= 2f;

        m_MonInt = 2;



        if(m_MaBoolean)
        {
            // Si m_MaBoolean == true
        }
        else
        {
            // Si m_MaBoolean == false;
        }

        if(m_MonFloat > 5f)
        {
            // Si m_MonFloat est plus grand que 5f
        }
        else if(m_MonFloat < -5f)
        {
            // Si m_MonFloat est plus petit que 5f
        }
        else
        {
            // Si m_MonFloat est entre -5f et 5f
        }
    }

    void Update()
    {
        //float monFloat;   

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Je vais passé ici le premier frame que je vais appuyer sur Q, mais plus après tant que je ne repèse pas une nouvelle fois sur Q
            Debug.Log("J'ai pesé sur Q");
        }

        if (Input.GetKey(KeyCode.W))
        {
            // Je vais passé ici tout les frame que la touche W va être appuyer
            Debug.Log("W est enfoncé");
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            // Je vais passé ici quand je vais relacher la touche E
            Debug.Log("E est relaché");
        }
    }

    void Jump()
    {

    }
}