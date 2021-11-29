using System;
using Polarith.AI.Move;
using UnityEngine;

public class EnemyView : BasePersonView, IHaveAim
{
    private EnemyState _state;
    private AIMContext _context;

    public EnemyState State
    {
        set => _state = value;
        get => _state;
    }
    public AIMContext Context
    {
        set => _context = value;
        get => _context;
    }


    private void OnDestroy()
    {
        GameEvents.Current.EnemyDead(this);
    }
    // public override void OnTriggerEnter(Collider other)
    // {
    //     base.OnTriggerEnter(other);
    //     if (other.gameObject.layer.Equals((int)Layers.Collectables))
    //     {
    //         if ((other.transform.position - transform.position).magnitude < 2f)
    //         {
    //             other.gameObject.SetActive(false);
    //         }
    //     }
    // }
}