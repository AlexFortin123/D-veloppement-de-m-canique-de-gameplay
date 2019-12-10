using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleNormalize : MonoBehaviour
{
    void Start()
    {
        // Je créé un nouveau vector 3 de 0,0,0
        Vector3 direction = new Vector3(0f, 0f, 0f);
        
        // Je met 1f dans son X
        direction.x = 1f;

        // La magnitude est la longeur d'un vecteur.
        // La magnitude est de 1
        Debug.Log(direction.magnitude);

        // Je reset la valeur en 0 de mon vecteur
        // Je met 1 dans la valeur Y de mon vecteur
        direction.x = 0f;
        direction.y = 1f;

        // La magnitude de mon vecteur est de 1
        Debug.Log(direction.magnitude);

        // Je met 1 dans X et dans Y dans mon vecteur
        direction.x = 1f;
        direction.y = 1f;

        // La magnitude résultante de cela est de 1.4142...
        Debug.Log(direction.magnitude);

        // direction.normalized me retourne le vecteur normalizer, le vecteur initial n'est pas changer
        // direction.normalized = (0.7f, 0.7f)
        Debug.Log(direction.normalized);

        // comme la direction initial n'est pas changer, on log (1,1)
        Debug.Log(direction);

        // Le .Normalize modifie directement le vecteur initial direction
        direction.Normalize();

        // direction est donc égale a (0.7f, 0.7f)
        Debug.Log(direction);
    }
}
