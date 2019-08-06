using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveMeshes 
{
    public GameObject NewHexagonPrimitive(string name, Material material)
    {
        Vector3[] vertices = new Vector3[6];
        Vector2[] uvs = new Vector2[6];
        int[] triangles = new int[12];

        vertices[0] = new Vector3(0, 0, 1);
        vertices[1] = new Vector3(1, 0, 2);
        vertices[2] = new Vector3(2, 0, 1);
        vertices[3] = new Vector3(0, 0, 0);
        vertices[4] = new Vector3(1, 0, -1);
        vertices[5] = new Vector3(2, 0, 0);

        uvs[0] = new Vector2(0, 1);
        uvs[1] = new Vector2(1, 2);
        uvs[2] = new Vector2(2, 1);
        uvs[3] = new Vector2(0, 0);
        uvs[4] = new Vector2(1, -1);
        uvs[5] = new Vector2(2, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;
        triangles[6] = 3;
        triangles[7] = 2;
        triangles[8] = 5;
        triangles[9] = 3;
        triangles[10] = 5;
        triangles[11] = 4;

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        GameObject gameObject = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer));

        gameObject.transform.localScale = new Vector3(5, 1, 5);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        gameObject.GetComponent<MeshRenderer>().material = material;


        return gameObject;
    }
}
