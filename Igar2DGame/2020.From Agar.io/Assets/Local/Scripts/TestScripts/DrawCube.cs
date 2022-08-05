using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCube : MonoBehaviour
{
    [SerializeField]
    private Texture Texture2DCustom;

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;

        mesh.Clear();

        //  Create Arrays which contain new values
        mesh.vertices = new Vector3[]
        {
                                new Vector3 (0, 0, 0),
                                new Vector3 (0, 1, 0),
                                new Vector3 (1, 1, 0),

                                new Vector3(1, 1, 0),
                                new Vector3(1, 0, 0),
                                new Vector3(0, 0, 0),

                                new Vector3(1, 1, 1),
                                new Vector3(1, 0, 0),
                                new Vector3(1, 1, 0),

                                new Vector3(1, 1, 1),
                                new Vector3(1, 0, 1),
                                new Vector3(1, 0, 0),

                                new Vector3(0, 0, 0),
                                new Vector3(1, 0, 1),
                                new Vector3(1, 1, 1)

        };

        mesh.uv = new Vector2[] { new Vector2(0, 0),
                                  new Vector2(0, 1),
                                  new Vector2(1, 1),

                                  new Vector2(1,  1),
                                  new Vector2(1,  0),
                                  new Vector2(0,  0),

                                  new Vector2(1,  1),
                                  new Vector2(1,  0),
                                  new Vector2(1,  1),

                                  new Vector2(1, 1),
                                  new Vector2(1, 0),
                                  new Vector2(1, 0),

                                  new Vector2(0, 0),
                                  new Vector2(1, 0),
                                  new Vector2(1, 0)


        };

        mesh.triangles = new int[] 
        {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11,
            12, 13, 14
        };

    }




}
