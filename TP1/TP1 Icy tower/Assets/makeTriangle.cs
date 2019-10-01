using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTriangle : MonoBehaviour
{
    public Vector3 SommetLeftTopFront = new Vector3(-1,1,1);
    public Vector3 SommetRightTopFront = new Vector3(1,1,1);
    public Vector3 SommetRgihtTopBack = new Vector3(1,1,-1);
    public Vector3 SommetLeftTopBack = new Vector3(-1,1,-1);
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;
        //sommets
        Vector3[] vertices = new Vector3[]
        {
            //front face
            SommetLeftTopFront,//left top front
            SommetRightTopFront,//right top front,
            new Vector3(-1,-1,1),//left bottom front
            new Vector3(1,-1,1),//right bottom front

            //back face
            SommetRgihtTopBack,//right top back
            SommetLeftTopBack,//left top back
            new Vector3(1,-1,-1),//right bottom back
            new Vector3(-1,-1,-1),//left bottom back

            //left face
            SommetLeftTopBack,//left top back
            SommetLeftTopFront,//left top front
            new Vector3(-1,-1,-1),//left bottom back
            new Vector3(-1,-1,1),//left bottom front

            //right face
            SommetRightTopFront,//right top front
            SommetRgihtTopBack,//right top back
            new Vector3(1,-1,1),//right bottom front
            new Vector3(1,-1,-1),//right bottom back

            //top face
            SommetLeftTopBack,//left top back
            SommetRgihtTopBack,//right top back
            SommetLeftTopFront,//left top front
            SommetRightTopFront,//right top front

            //bottome face
            new Vector3(-1,-1,1),//left bottom front
            new Vector3(1,-1,1),//right bottom front
            new Vector3(-1,-1,-1),//left bottom back
            new Vector3(1,-1,-1)//right bottom back
        };
        //triangle
        int[] triangles = new int[]
        {
           //front face
           0,2,3,//first triangle
           3,1,0,//second triangle

           //back face
           4,6,7,//first triangle
           7,5,4,//second triangle

           //left face
           8,10,11,//first triangle
           11,9,8,//second triangle

           //right face
           12,14,15,//first triangle
           15,13,12,//second triangle

           //top face
           16,18,19,//first triangle
           19,17,16,//second triangle

           //bottom face
           20,22,23,//first triangle
           23,21,20//second triangle
        };
        //UVs
        Vector2[] uvs = new Vector2[]
        {
            //fornt face// 0,0 is bottom left, 1,1 is top right
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
