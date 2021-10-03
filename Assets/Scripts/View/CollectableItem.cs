using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    [SerializeField] private ParticleSystem _collectables;
    [SerializeField] private Transform _obj;
    public int Points { get; set; }
    private ParticleSystem.Particle _temp;
    private List<ParticleSystem.Particle> _enter = new List<ParticleSystem.Particle>();
    void OnParticleCollision(GameObject other)
    {
        _obj = other.gameObject.transform;
        _collectables.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _enter);
        int number = _enter.Count;
        Debug.Log(_obj.position);
        for (int i = 0; i<_enter.Count; i++)
        {

            _temp = _enter[i];
            _temp.position = Vector3.MoveTowards(_temp.position,  _temp.position - _obj.position, 10);
        }
    }
    
}
