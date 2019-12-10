using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ExempleEnum m_ExempleEnum;
    private Rigidbody m_RigidBody;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float jumpBoost = 5f;
            if(m_ExempleEnum.HaveToken(ExempleEnum.TokenType.RocketJump))
            {
                jumpBoost *= 2f;
                m_ExempleEnum.ConsumeToken(ExempleEnum.TokenType.RocketJump);
            }
            m_RigidBody.AddForce(Vector3.up * jumpBoost, ForceMode.Impulse);
        }
    }
}
