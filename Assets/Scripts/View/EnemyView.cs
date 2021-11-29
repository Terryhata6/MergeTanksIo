using System;
using Polarith.AI.Move;
using UnityEngine;

public class EnemyView : BaseObjectView, IHaveAim
{
    private EnemyState _state;
    private AIMContext _context;
    [SerializeField]private PerkManager _perks;
    [SerializeField]private ViewParamsComponent _params;

    private void Start()
    {
        _params = new ViewParamsComponent();
        _perks = new PerkManager(_params);
    }

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(Layers.Collectables))
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}