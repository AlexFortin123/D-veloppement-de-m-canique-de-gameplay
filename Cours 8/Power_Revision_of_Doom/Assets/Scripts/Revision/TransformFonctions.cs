using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFonctions : MonoBehaviour
{
    Vector3 m_MonVecteur; // Déclare une variable de type Vector3, elle n'est pas initialiser en mémoire, mon code dit juste que je vais avoir une variable de ce type;

    Vector3 m_MonDeplacement;

    float m_Speed;

    Vector3 m_MaRotation;

    // Start is called before the first frame update
    void Start()
    {

        // MonVecteur 3 est déclaré a (0f,0f,0f). donc c'est l'équivalent d'avoir 3 variables float qui ont une valeure de 0f
        //m_MonVecteur = new Vector3();
        //m_MonVecteur.x;
        //m_MonVecteur.y;
        //m_MonVecteur.z;

        //float x;
        //float y;
        //float z;

        // Ces valeurs ne change jamais, elles ne sont ratacher a un transform, donc peu importe la rotation de notre GameObject, c'est valeur reste les mêmes.
        //Vector3.zero; // (0f,0f,0f);
        //Vector3.one; // (1f,1f,1f);
        //Vector3.up; // (0f,1f,0f);
        //Vector3.forward; // (0f,0f,1f);
        //Vector3.right; // (1f,0f,0f);

        // Ces valeurs change selon la rotation du transform.
        //transform.up;
        //transform.forward;
        //transform.right;


        m_MonDeplacement = new Vector3(1f, 0f, 0f);
        m_Speed = 5f;

        m_MaRotation = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Vector3.up : " +  Vector3.up);
        Debug.Log("transform.up" + transform.up);


        // Fonction de translation, don
        transform.Translate(m_MonDeplacement * Time.deltaTime * m_Speed);
        // Space.World = Déplacement dans le world, donc ne se fie pas a la rotation du cube.
        // Space.Self = Déplacement par rapport a lui meme, donc se fie a la rotation.
        // De base si ni l'un ni l'autre n,est passé a la fonction, on utilise Space.self.


        transform.Rotate(transform.up, 1f );
    }
}
