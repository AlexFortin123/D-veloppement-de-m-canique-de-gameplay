using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public Transform m_Parent;

    void Update()
    {
        // Delta X de souris, movement en X entre le frame courant et le dernier Frame
        //float mouseMoveX = Input.GetAxis("Mouse X");
        // Delta Y de souris, movement en X entre le frame courant et le dernier Frame
        //float mouseMoveY = -Input.GetAxis("Mouse Y");

        //transform.Rotate(Vector3.right, mouseMoveY * Time.deltaTime * 100f);
        //m_Parent.Rotate(Vector3.up, mouseMoveX * Time.deltaTime * 100f);

        float joyStickX = Input.GetAxis("JoyStickX");
        float joyStickY = Input.GetAxis("JoyStickY");

        Debug.Log("JoyStickX : " + joyStickX);
        Debug.Log("JoyStickY : " + joyStickY);

        transform.Rotate(Vector3.right, joyStickY * Time.deltaTime * 1000f);
        m_Parent.Rotate(Vector3.up, joyStickX * Time.deltaTime * 1000f);
    }
}
