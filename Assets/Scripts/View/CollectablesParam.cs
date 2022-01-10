using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectablesParam : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private MeshFilter _mesh;
    [SerializeField] private Transform _ground;
    [SerializeField] private int _respawnDelay;
    [SerializeField] private List<CollectableItem> _examples;

    public int Size => _size;
    public Vector3[] Vertices => _mesh.mesh.vertices;
    public Transform Ground => _ground;
    public int RespawnDelay => _respawnDelay;
    public List<CollectableItem> Examples => _examples;
}
