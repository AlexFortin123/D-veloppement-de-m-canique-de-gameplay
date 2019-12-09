using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControlleur : MonoBehaviour
{
    private bool m_CanOpenDoor1;
    private bool m_CanOpenDoor2;
    private ButtonController m_ButtonController1;
    private ButtonController m_ButtonController2;

    private void Awake()
    {
        m_CanOpenDoor1 = false;
        m_CanOpenDoor2 = false;
        m_ButtonController1 = transform.GetChild(0).GetComponent<ButtonController>();
        m_ButtonController2 = transform.GetChild(1).GetComponent<ButtonController>();
    }
    private void Update()
    {
        m_CanOpenDoor1 = m_ButtonController1.GetCanOpenDoor();
        Debug.Log("m_CanOpenDoor1" + m_CanOpenDoor1);
        m_CanOpenDoor2 = m_ButtonController2.GetCanOpenDoor();
        Debug.Log("m_CanOpenDoor2" + m_CanOpenDoor2);
        if (m_CanOpenDoor1 && m_CanOpenDoor2)
        {
            StartCoroutine("CloseDoor");
        }
    }

    IEnumerator CloseDoor()
    {
        while (gameObject.transform.position.y > -5f)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }
}
