using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CircleGenerator : MonoBehaviour
{
    [SerializeField]
    private int _Size, _aRraySize;
    private Vector3[] _vertices;
    
    private void Update()
    {
        Generate();
    }

    private void Generate()
    {
        var _angle = Mathf.PI / (_aRraySize / 2f);


        _vertices = new Vector3[_aRraySize];

        for (int i = 0; i < _vertices.Length; i++)
        {
            var x = Mathf.Cos(_angle * i) * _Size;
            var z = Mathf.Sin(_angle * i) * _Size;
            _vertices[i] = new Vector3(x, 0, z) + transform.position;
            _vertices[i] = transform.rotation * (_vertices[i] - transform.position) + transform.position;
            transform.Rotate(Vector3.up * Time.deltaTime * 100f);
        }
    }

    private void Trans() { }

    private void OnDrawGizmos()
    {
        if (_vertices == null) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], 0.1f);
        }
    }
}