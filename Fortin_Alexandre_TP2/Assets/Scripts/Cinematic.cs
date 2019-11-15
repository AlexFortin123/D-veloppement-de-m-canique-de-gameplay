using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script qui permet de transmettre Un signal à la caméra. elle dit qu'il faut que la caméra cesse de suivre le joueur et d'aller vers 
 * un cetain point dans le jeu
 */
public class Cinematic : MonoBehaviour
{
    public Camera m_MainCamera;
    public Transform m_TransformNewPosCamera;

    private CameraFollow m_CameraFollow;

    private void Awake()
    {
        //prend les composantes de la camera principal
        m_CameraFollow = m_MainCamera.GetComponent<CameraFollow>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Si le trigger entre en contact avec le joueur, il envoie un signal a la camera de bouger en lui transmettant le transform
        //de la position ou la camera doit se rendre et transmet la position original de la camera pour le lerp de retour de la camera
        //vers le joueur et met m_CanMouveWithPlayer a false pour que la caméra cesse de suivre le joueu
        //
        if (other.gameObject.tag == "Player")
        {
            m_CameraFollow.m_NewTranformCinematic = m_TransformNewPosCamera;
            m_CameraFollow.m_CanMouveWithPlayer = false;
            m_CameraFollow.m_InitialPositionCamera = m_MainCamera.transform;
        }
    }
}
