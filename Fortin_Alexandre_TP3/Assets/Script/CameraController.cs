using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script qui détermine le comportement de la caméra
 */
public class CameraController : MonoBehaviour
{
    public Transform m_CanvasCameraTransform;
    
    private float m_MouseMoveX;
    private float m_MouseMoveY;

    void Update()
    {
        m_MouseMoveX = Input.GetAxis("Mouse X");//Prend en parametre le mouvement de la camera en X par rapport à la position de la souris
        m_MouseMoveY = -Input.GetAxis("Mouse Y");//Prend en parametre le mouvement de la camera en Y par rapport à la position de la souris

        //m_MouseMoveY = Mathf.Clamp(m_MouseMoveY, -30f, 30f);
        transform.Rotate(Vector3.right, m_MouseMoveY * Time.deltaTime * 100f);
        m_CanvasCameraTransform.Rotate(Vector3.up, m_MouseMoveX * Time.deltaTime * 100f);
        
    }
}
