using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Vector3 m_start;
    public Vector3 m_End;

    private float m_Percentage;
    // Start is called before the first frame update
    void Start()
    {
        m_Percentage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_Percentage += Time.deltaTime * 0.2f;

        //60fps, pour 1 seconde, il roule 60 fois le code update = 0.0167, donc deltaTime fais *60 pour avoir une seconde
        if(m_Percentage >= 1f)
        {
            m_Percentage = 1f;
        }
        transform.position = Vector3.Lerp(m_start, m_End, m_Percentage);// lerp prend trois paramètres, la position de départ, la position de fin, le pourcentage
        //entre les deux position
        
    }
}
