using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObject : MonoBehaviour
{
    // Declarer une variable Vector3 pour la direction de notre translation.
    // On appelle une variable avec m_ quand c'est une variable de classe
    public Vector3 m_Direction = new Vector3(0f, 1f, 0f);

    void Update()
    {
        // Time.delaTime = Durée entre le frame présent et le dernier frame
        // Donc 60 FPS, Time.deltaTime = 1 / 60 = 0.016666666;
        transform.Translate(m_Direction * Time.deltaTime); // Bouger dans la direction m_Direction a tout les secondes.

        // On appelle une variable sans m_ pour les variables qui sont de scope de fonction
        float exempleFloat = 5f;
    }
}
