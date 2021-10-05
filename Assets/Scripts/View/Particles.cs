using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private List<CollectableItem> _prefab;
    private Transform _target;

    private void Start()
    {
        FindObjectOfType<MainController>().GetController<CollectableController>().SetParticles(this);
    }

    public List<CollectableItem> Prefabs => _prefab;
    public ParticleSystem System => _ps;
    public Transform Target => _target;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform;
        }
    }
}
