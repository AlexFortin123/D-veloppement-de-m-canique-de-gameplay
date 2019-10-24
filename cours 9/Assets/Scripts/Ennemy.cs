using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public GameObject m_Player;
    private int hp;

    private void Awake()
    {
        hp = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balle")
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
