using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Vector3 m_Direction;

    void Update()
    {
        transform.Translate(10f * m_Direction * Time.deltaTime);
    }
}
