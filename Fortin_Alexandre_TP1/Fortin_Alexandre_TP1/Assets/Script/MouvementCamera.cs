using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCamera : MonoBehaviour {
    Vector3 newPos;
    private float cam_speed = 0.01f;
    public GameObject joueur;
    public Camera cam;
	// Use this for initialization
	void Start () {
        newPos = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
        newPos = transform.position;
        if(transform.position.y < 65.42f)
        {
            if (cam.WorldToViewportPoint(joueur.transform.position).y >= 0.75)
            {
                if (cam.WorldToViewportPoint(joueur.transform.position).y >= 0.50f)
                {
                    cam_speed = 0.05f;
                    newPos.y = newPos.y + cam_speed;
                    transform.position = newPos;
                }
            }
            else
            {
                cam_speed = 0.01f;
                newPos.y = newPos.y + cam_speed;
                transform.position = newPos;
            }
        }
    }
}
