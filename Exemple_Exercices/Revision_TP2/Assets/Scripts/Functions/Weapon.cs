using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On a besoin de specifier qu'une classe est serializable si on veut qu'elle apparaisse dans l'editor
[System.Serializable]
public class Weapon
{
    public int m_Damage;
    public float m_Range;
    public string m_Name;
}