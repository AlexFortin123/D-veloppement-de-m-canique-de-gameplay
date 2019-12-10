using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExempleEnum : MonoBehaviour
{
    public enum TokenType
    {
        RocketJump,
        SpeedBoost,
        Clone,
        Prout
    }

    private TokenType m_MyToken;

    private List<TokenType> m_AllToken;

    // Start is called before the first frame update
    void Start()
    {
        m_AllToken = new List<TokenType>();

        m_MyToken = TokenType.RocketJump;

        if(m_MyToken == TokenType.RocketJump)
        {
            // Fait un jump plus haut
        }
        else
        {
            // Fait un jump normal
        }
    }

    public void CollectToken(TokenType i_TokenType)
    {
        m_MyToken = i_TokenType;

        if(m_AllToken.Contains(i_TokenType) == false)m_AllToken.Add(i_TokenType);
    }

    public bool HaveToken(TokenType i_TokenType)
    {
        return m_AllToken.Contains(i_TokenType);
    }

    public void ConsumeToken(TokenType i_TokenType)
    {
        m_AllToken.Remove(i_TokenType);
    }
}
