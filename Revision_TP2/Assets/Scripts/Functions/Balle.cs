using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public Rigidbody m_RigidBody;

    private float m_Speed;
    private int m_Damage;

    public void Shoot(Vector3 i_Direction, float i_Speed, int i_Damage)
    {
        m_RigidBody.velocity = i_Direction;
        m_Speed = i_Speed;
        m_Damage = i_Damage;
    }
}
