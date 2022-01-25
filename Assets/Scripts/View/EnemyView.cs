using System;
using Polarith.AI.Move;
using UnityEngine;

public class EnemyView : BasePersonView, IHaveAim, ITransaction
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

    public override void IsDead()
    {
        if (ViewParams.IsDead())
        {
            GameEvents.Current.EnemyDead(this);
        }
        base.IsDead();
    }

    //Doonn Покупка 
    protected override void StartTransaction()
    {
        if (ViewParams.IsDead())
        {
            return;
        }
        base.StartTransaction();
        Transaction transaction = new Transaction();
        transaction.Value = _points;
        transaction.WhoBuy = gameObject;
        StoreSystem.SetBuy(transaction);
    }

    public void CompleteTransaction(Transaction transaction)
    {
        if (ViewParams.IsDead())
        {
            return;
        }
        if(_shooter == null) return;
        _points = transaction.Value;
        PerkManager.AddPerk(transaction.Perk);
    }
    //
}