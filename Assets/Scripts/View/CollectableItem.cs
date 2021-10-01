using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    [SerializeField] private ParticleSystem _collectables;
    [SerializeField] private Transform _obj;
    public int Points { get; set; }
    private ParticleSystem.Particle _temp;
    private List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    void Awake()
    {


    }

    void OnParticleTrigger()
    {
        

        // get
        int numEnter = _collectables.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        if (numEnter > 0)
        {
            Debug.Log("EEEEEEEEE");
        }

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            _temp = enter[i];
            _temp.startColor = new Color32(255, 0, 0, 255);
            _temp.position = Vector3.MoveTowards(_temp.position,_obj.position,0.2f);
            enter[i] = _temp;
        }

        // set
        _collectables.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
