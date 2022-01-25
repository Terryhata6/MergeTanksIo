using System;
using System.Collections.Generic;
using Polarith.AI.Move;
using UnityEngine;

public class EnemyView : BasePersonView, IHaveAim, ITransaction
{
    #region  Private fields
    private EnemyState _state;
    private AIMContext _context;
    private Dictionary<SeekLabels, AIMSeek> _seekers;
    private bool _onBorderOfMap;
    private float _reactionTime;
    private float _coolDown;
    #endregion
    
    #region Access Fields
    public bool OnBorderOfMap => _onBorderOfMap;
    public float ReactionTime
    {
        get => _reactionTime; 
        set => _reactionTime=value;
    }

    public float CoolDown
    {
        get => _coolDown; 
        set => _coolDown=value;
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

    public float AIMCollectableValue
    {
        get
        {
            if (_context)
            {
                return _context.Context.Decision.Values[0];
            }

            return 0f;
        }
    }
    public float AIMEnemyValue
    {
        get
        {
            if (_context)
            {
                return _context.Context.Decision.Values[2];
            }

            return 0f;
        }
    }
    public float AIMMergeValue
    {
        get
        {
            if (_context)
            {
                return _context.Context.Decision.Values[3];
            }

            return 0f;
        }
    }
    #endregion
    
    private void Start()
    {
        _onBorderOfMap = false;
        if (_reactionTime == 0f)
        {
            _reactionTime = 0.5f;
        }
    }
    
    public void SetSeekers(List<SeekDictionary> dict)
    {
        _seekers = new Dictionary<SeekLabels, AIMSeek>();
        for (int i = 0; i < dict.Count; i++)
        {
            _seekers.Add(dict[i].Label,dict[i].Seek);
        }
    }
    
    public void ChangeSeekMultiplier(SeekLabels label, float multiplier)
    {
        if (_seekers.ContainsKey(label))
        {
            _seekers[label].Seek.MagnitudeMultiplier = multiplier;
        }
    }

    private void TurnLowPrioryAllSeekers()
    {
        for (int i = 0; i < _seekers.Count; i++)
        {
            ChangeSeekMultiplier((SeekLabels)i , 0.1f);
        }
    }

    private void TurnOffAllSeek()
    {
        for (int i = 0; i < _seekers.Count; i++)
        {
            _seekers[(SeekLabels)i].enabled = false;
        }
    }
    
    public void TurnOnSeek(SeekLabels label)
    {
        TurnOffAllSeek();
        if (_seekers.ContainsKey(label))
        {
            _seekers[label].enabled = true;
        }
    }

    public void TurnOnAllSeek()
    {
        for (int i = 0; i < _seekers.Count; i++)
        {
            _seekers[(SeekLabels)i].enabled = true;
        }
    }
    
    public void SetSeekPriory(SeekLabels label)
    {
        TurnLowPrioryAllSeekers();
        if (_seekers.ContainsKey(label))
        {
            ChangeSeekMultiplier(label , 1f);
        }
    }

    public void CountReactionCooldown()
    {
        _coolDown -= Time.deltaTime;
    }
    
    public void Move(Vector3 dir)
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(dir), 
            Time.deltaTime * ViewParams.RotationSpeed);
        transform.position += transform.forward * Time.deltaTime * ViewParams.MoveSpeed;
    }

    public void GetAimDirect(out Vector3 dir)
    {
        dir = Context.DecidedDirection; 
        dir.y = 0f;
    }
    
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        CheckBorderOfMap(other);
    }

    private void CheckBorderOfMap(Collider other)
    {
        if (other.gameObject.layer.Equals((int) Layers.BorderOfMap))
        {
            _onBorderOfMap = true;
        }
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