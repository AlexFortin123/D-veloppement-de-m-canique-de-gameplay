﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject ball;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + pos;
    }
}
