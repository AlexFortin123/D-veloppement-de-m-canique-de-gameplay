using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCamera : MonoBehaviour {
    Vector3 newPos;
    private float cam_speed = 0.01f;
	// Use this for initialization
	void Start () {
        newPos = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
        newPos = transform.position;
        newPos.y = newPos.y + cam_speed;
        transform.position = newPos;
	}
}
