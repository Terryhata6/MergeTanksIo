using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private List<CollectableItem> _prefab;
    
    public List<CollectableItem> Prefabs => _prefab;
    public ParticleSystem System => _ps;

    // private void OnParticleCollision(GameObject other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         _target = other.transform;
    //     }
    // }
}
