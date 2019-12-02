using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController m_Player;
    public List<GameObject> m_ListRocketJumpButton;
    public List<GameObject> m_ListShrinkButton;
    public List<GameObject> m_ListCloneButton;
    public List<GameObject> m_ListDoubleSpeedButton;

    public Image m_ImageRocketJump;
    public Image m_ImageShrink;
    public Image m_ImageClone;
    public Image m_ImageDoubleSpeed;

    public void RocketJumpActivated()
    {
        for (int i = 0; i < m_ListRocketJumpButton.Count; i++)
        {
            m_ListRocketJumpButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
        m_ImageRocketJump.enabled = true;
    }
    public void ShrinkButtonActivated()
    {
        for (int i = 0; i < m_ListShrinkButton.Count; i++)
        {
            m_ListShrinkButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
        m_ImageShrink.enabled = true;
    }
    public void CloneButtonActivated()
    {
        for (int i = 0; i < m_ListCloneButton.Count; i++)
        {
            m_ListCloneButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
        m_ImageClone.enabled = true;
    }
    public void DoubleSpeedButtonActivated()
    {
        for (int i = 0; i < m_ListDoubleSpeedButton.Count; i++)
        {
            m_ListDoubleSpeedButton[i].GetComponent<CapsuleCollider>().enabled = false;
        }
        m_ImageDoubleSpeed.enabled = true;
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
        for (int i = 0; i < m_ListDoubleSpeedButton.Count; i++)
        {
            m_ListDoubleSpeedButton[i].GetComponent<CapsuleCollider>().enabled = true;
        }
        m_ImageRocketJump.enabled = false;
        m_ImageShrink.enabled = false;
        m_ImageClone.enabled = false;
        m_ImageDoubleSpeed.enabled = false;
    }
}
