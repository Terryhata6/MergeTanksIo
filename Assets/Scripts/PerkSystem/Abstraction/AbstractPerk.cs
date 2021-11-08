using UnityEngine;

public enum PerkType
{
    Defence,
    Offence
}


public abstract class AbstractPerk : ScriptableObject, IPerk
{

    [SerializeField] protected bool _onEnable = false;
    public bool OnEnable => _onEnable;


    [SerializeField][Tooltip("Перк Срабатывает при FixedUpdate")] protected bool _fixedExecute;
    public bool FixedExecute => _fixedExecute;

    [SerializeField] protected PerkType _typePerk = PerkType.Defence;
    public PerkType TypePerk => _typePerk;

    protected int _priority;
    public int Priority => _priority;

    [SerializeField] protected int _level;
    public int Level => _level;
    
    [SerializeField] protected int _maxLevel;
    public int MaxLevel => _maxLevel;

    public virtual void Activate(PlayerView ownPlayer) { }
    public virtual void Activate(Shooter ownShoot) { }

    public virtual void Activ(Projectile ownProjectile, GameObject target) { }
    public virtual void Activ(Projectile ownProjectile) { }

    public virtual void Deactivate(PlayerView ownPlayer) { }
    public virtual void Deactivate(Shooter ownShoot) { }
    public virtual void AddLevel(){}
    public virtual void RemoveLevel(){}
}