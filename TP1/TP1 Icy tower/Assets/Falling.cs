using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Vector3 newPos;
    private float speedFalling = 0;
    public Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        newPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;
        newPos.y += speedFalling;
        transform.position = newPos;

        if (m_camera.WorldToViewportPoint(transform.position).y <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            speedFalling = -0.1f;
        }
    }
}
