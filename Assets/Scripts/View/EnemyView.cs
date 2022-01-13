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

    public override void  IsDead()
    {
        if (ViewParams.IsDead())
        {
            GameEvents.Current.EnemyDead(this);
        }
        base.IsDead();
    }
}