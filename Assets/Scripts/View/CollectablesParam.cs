using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectablesParam : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private MeshFilter _mesh;
    [SerializeField] private int _respawnDelay;
    [SerializeField] private int _collectablesPerSpawn;
    [SerializeField] private List<CollectableItem> _examples;

    public int Size => _size;
    public Vector3[] Vertices => _mesh.mesh.vertices;
    public int RespawnDelay => _respawnDelay;
    public int CollectablesPerSpawn => _collectablesPerSpawn;
    public List<CollectableItem> Examples => _examples;
}
