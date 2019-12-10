using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Player m_Player;
    private Vector3 m_LastCheckPoint;

    public void SetLastCheckPoint(Vector3 i_LastCheckPoint)
    {
        m_LastCheckPoint = i_LastCheckPoint;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            m_Player.transform.position = m_LastCheckPoint;
        }
    }
}
