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
    private Vector3 m_NewRotate;
    void Update()
    {
        m_MouseMoveX = Input.GetAxis("Mouse X");//Prend en parametre le mouvement de la camera en X par rapport à la position de la souris
        m_MouseMoveY = -Input.GetAxis("Mouse Y");//Prend en parametre le mouvement de la camera en Y par rapport à la position de la souris

        transform.Rotate(Vector3.right, m_MouseMoveY * Time.deltaTime * 100f);
        m_CanvasCameraTransform.Rotate(Vector3.up, m_MouseMoveX * Time.deltaTime * 100f);

        //Euler retourne une valeur entre 0 et 360, pour pouvoir avoir le nombre négatif il faut soustraire 360 dès que la valeur 
        //en x dépasse 180 degrée
        m_NewRotate = transform.localRotation.eulerAngles;
        if(m_NewRotate.x > 180f)
        {
            m_NewRotate.x -= 360f;
        }
        m_NewRotate.x = Mathf.Clamp(m_NewRotate.x, -60f, 60f);
        transform.localRotation = Quaternion.Euler(m_NewRotate);

    }
}
