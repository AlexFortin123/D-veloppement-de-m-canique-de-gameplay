using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public ExempleEnum.TokenType m_MonTokenType;
    public ExempleEnum m_ExempleEnum;

    private void OnTriggerEnter(Collider other)
    {
        m_ExempleEnum.CollectToken(m_MonTokenType);
    }
}
