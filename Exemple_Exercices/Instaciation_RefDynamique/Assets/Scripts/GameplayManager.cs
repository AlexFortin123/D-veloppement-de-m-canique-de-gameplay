using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject m_ObjectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(m_ObjectToSpawn, Vector3.zero, Quaternion.identity); 
    }
}
