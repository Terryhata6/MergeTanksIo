using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        //Vector3[] vertices = mesh.vertices;
        //Vector2[] uvs = new Vector2[vertices.Length];
        Bounds bounds = mesh.bounds;
        Debug.Log("Bounds: " + bounds);
        Debug.Log("BoundsSize: " + bounds.size);
        int i = 0;
        // while (i < uvs.Length)
        // {
        //     uvs[i] = new Vector2(vertices[i].x / bounds.size.x, vertices[i].z / bounds.size.x);
        //     i++;
        // }
        // mesh.uv = uvs;
        // Debug.Log("UVS: "+ uvs[0]);
    }
}