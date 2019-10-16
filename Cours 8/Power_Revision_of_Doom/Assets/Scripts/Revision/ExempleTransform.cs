using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleTransform : MonoBehaviour
{
    // Transform avec un T majuscule est le type.
    Transform m_MonTransform;

    void Start()
    {
        // transform avec un t minuscule est l'accesseur au transform de notre gameobject
        //transform.position; // Le transform comporte 3 variables. La postion ( Vector3 ) , Rotation ( Quaternion ) , LocalScale ( Vector3 )

        //transform.rotation; // La rotation est un Quaternion, mais nous transposons le quaternion en Vector3 avec Quaternion.Euler ou transform.rotation.
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); // Transforme mon Vector3 en quaternion
        //transform.eulerAngles // Retourne la rotation en Vector3 (x,y,z)

        //transform.localScale; // Le LoccalScale est un Vector3



        //transform.localPosition; // La local Position, est la position du gameObject par rapport a son parent.
        //transform.localRotation; // La local rotation, est la rotation du gameObject par rapport a son parent.
    }

    void Update()
    {
        
    }
}
