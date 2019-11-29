using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController m_Player;
    public List<GameObject> m_ListRocketJumpButton;
    public List<GameObject> m_ListShrinkButton;
    public List<GameObject> m_ListCloneButton;

    public void RocketJumpActivated()
    {
        for (int i = 0; i < m_ListRocketJumpButton.Count; i++)
        {
            m_ListRocketJumpButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    public void ShrinkButtonActivated()
    {
        for (int i = 0; i < m_ListShrinkButton.Count; i++)
        {
            m_ListShrinkButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    public void CloneButtonActivated()
    {
        for (int i = 0; i < m_ListCloneButton.Count; i++)
        {
            m_ListCloneButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    public void ResetButtonActivated()
    {
        for (int i = 0; i < m_ListRocketJumpButton.Count; i++)
        {
            m_ListRocketJumpButton[i].GetComponent<CapsuleCollider>().enabled = true;
        }
        for (int i = 0; i < m_ListShrinkButton.Count; i++)
        {
            m_ListShrinkButton[i].GetComponent<CapsuleCollider>().enabled = true;
        }
        for (int i = 0; i < m_ListCloneButton.Count; i++)
        {
            m_ListCloneButton[i].GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
