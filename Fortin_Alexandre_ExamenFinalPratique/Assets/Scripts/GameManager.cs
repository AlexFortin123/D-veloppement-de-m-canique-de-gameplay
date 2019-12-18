using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject m_Reward;
    public GameObject m_Obstacle;
    public float m_Timer;

    private bool m_PlayerGetReward;
    private Scene m_CurrentScene;
    private RaycastHit m_HitObstacle;
    private Vector3 m_DefaultScale;

    private void Awake()
    {
        m_PlayerGetReward = false;
        m_CurrentScene = SceneManager.GetActiveScene();
        m_DefaultScale = m_Obstacle.transform.localScale;
    }
    void Update()
    {
        m_Timer -= Time.deltaTime;
        if (m_Timer <= 0 || m_PlayerGetReward == true)
        {
            Destroy(m_Reward);
        }

        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(m_CurrentScene.name);
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            m_Obstacle.transform.localScale /= 2;
        }
        if (Input.GetMouseButtonDown(1))
        {
            m_Obstacle.transform.localScale = m_DefaultScale;
        }
    }
    public void PlayerGetReward()
    {
        m_PlayerGetReward = true;
    }
}
