using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script qui détermine le comportement de la caméra, elle doit suivre le joueur a une certaine distance
 * et bloquer lorsqu'elle arrive sur les bords de la map.
 */
public class CameraFollow : MonoBehaviour
{
    public GameObject m_Player;
    public Transform m_BordureMapDroite;
    public Transform m_BordureMapGauche;
    public Transform m_BordureMapHaut;
    public Transform m_BordureMapBas;
    public Transform m_NewTranformCinematic;
    public Transform m_InitialPositionCamera;
    public bool m_CanMouveWithPlayer;
    public bool m_OtherCanMove;

    private Vector3 m_NewPos;
    private Vector3 m_PositionPlayer;
    private float m_Pourcentage;
    private bool m_BackToInitialPosition;
    private Quaternion m_QuaternionInitialCamera;
    
    //set les variables lors du lancement du jeu
    private void Awake()
    {
        m_CanMouveWithPlayer = true;
        m_Pourcentage = 0f;
        m_BackToInitialPosition = false;
        m_QuaternionInitialCamera = transform.rotation;
        m_OtherCanMove = true;
    }
    void Update()
    {
        //if qui permet de faire la différence entre la camera de la minimap et la camera principal
        //les deux ont le même script
        if(this.tag == "MinimapCamera")
        {
            m_NewPos = m_Player.transform.position;
            m_NewPos.y = m_Player.transform.position.y + 100f;
            transform.position = m_NewPos;
        }
        else
        {
            //si le joueur attive un trigger cinematic, la camera va se déplacer seul vers une position puis revenir
            //m_CanMouveWithPlayer se met a false quand le joueur entre en contact avec un trigger cinematic
            if (m_CanMouveWithPlayer)
            {
                m_NewPos = m_Player.transform.position;
                //Clamp en x qui empêche la caméra de dépasse la position en x de la bordure gauche(minimum) et droite(maximum)
                m_NewPos.x = Mathf.Clamp(m_NewPos.x, m_BordureMapGauche.position.x, m_BordureMapDroite.position.x);
                //Clamp en z qui empêche la caméra de dépasse la position en x de la bordure bas(minimum) et haut(maximum) et on soustrait 12
                //a la position pour que la caméra reste éloigner du joueur
                m_NewPos.z = Mathf.Clamp(m_NewPos.z - 12f, m_BordureMapBas.position.z, m_BordureMapHaut.position.z);
                m_NewPos.y = m_Player.transform.position.y + 12f;
                transform.position = m_NewPos;
            }
            else
            {
                //if qui dit si la camera fait son premier lerp pour se rendre à la position demander par le trigger cinematic ou
                //si il est a son deuxième lerp qui permet à la caméra de revenir vers le joueur. si m_CanMouveWithPlayer est faux,
                //la camera est dans son premier lerp, si il est vrai la camera est dans son deuxième. Une fois le deuxième lerp fini
                //le m_CanMouveWithPlayer devient vrai et le m_CanMouveWithPlayer devient vrai
                if (!m_BackToInitialPosition)
                {
                    //premier lerp vers la position demander
                    m_OtherCanMove = false; // empeche les ennemy et le joueur de bouger pendant le mouvement de camera
                    transform.position = Vector3.Lerp(m_InitialPositionCamera.position, m_NewTranformCinematic.position, m_Pourcentage);
                    transform.rotation = Quaternion.Lerp(m_InitialPositionCamera.rotation, m_NewTranformCinematic.rotation, m_Pourcentage);
                    m_Pourcentage += 0.3f * Time.deltaTime;
                    if (m_Pourcentage >= 1f)
                    {
                        m_BackToInitialPosition = true;
                        m_Pourcentage = 0;
                        m_PositionPlayer = new Vector3(m_Player.transform.position.x,
                        m_Player.transform.position.y + 12f, m_Player.transform.position.z - 12f);
                    }
                }
                else
                {
                    //deuxième lerp vers le joueur
                    transform.position = Vector3.Lerp(m_NewTranformCinematic.position, m_PositionPlayer, m_Pourcentage);
                    transform.rotation = Quaternion.Lerp(m_NewTranformCinematic.rotation, m_QuaternionInitialCamera, m_Pourcentage);
                    m_Pourcentage += 0.3f * Time.deltaTime;
                    if (m_Pourcentage >= 1f)
                    {
                        m_CanMouveWithPlayer = true;
                        m_BackToInitialPosition = false;
                        m_OtherCanMove = true; // permet au joueur et au ennemy de se remettre à bouger
                        m_Pourcentage = 0;
                    }
                }
            }
            
        }
        
    }
}
