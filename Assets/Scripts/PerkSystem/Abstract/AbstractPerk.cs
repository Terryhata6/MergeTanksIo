using UnityEngine;

public abstract class AbstractPerk : ScriptableObject
{
    #region Base Parametr Perk
    [SerializeField] protected PerkDataStruct _perkData;
    public PerkDataStruct PerkData => _perkData;
    [SerializeField] protected AbstractPerk _conflictPerk;
    public AbstractPerk ConflictPerk => _conflictPerk;
    #endregion

    #region  PlayerViewParams
    protected ViewParamsComponent _ownViewParams;
    public virtual void Activate(ViewParamsComponent ownViewParams)
    {
        _ownViewParams = ownViewParams;
    }
    public virtual void Deactivate(ViewParamsComponent ownViewParams) { }

    //"Перк Срабатывает при FixedUpdate или Update" >> отрабатывает каждый Кадр 
    protected bool _isActiveBuff;
    public bool IsActiveBuff => _isActiveBuff;
    public virtual void ActivateBuff(ViewParamsComponent viewParams) { }
    #endregion

    #region  WeaponParametr
    protected Shooter _ownShooter;
    public virtual void Activate(Shooter ownShooter)
    {
        _ownShooter = ownShooter;
    }
    public virtual void Deactivate(Shooter ownShooter) { }
    public virtual void ActivateBuff(Shooter ownShooter) { }
    #endregion



    #region Projectile Parametr Modification
    protected GameObject _target;
    protected BaseProjectile _ownProjectile;

    public enum TypeModification
    {
        Debuff,
        Modification
    }
    protected TypeModification _modificationType = TypeModification.Modification;
    public TypeModification ModificationType => _modificationType;

    public virtual void ActivateModification(BaseProjectile ownProjectile) 
    { 
        _ownProjectile = ownProjectile;
    }

    public virtual void ActivateHit(BaseProjectile ownProjectile, GameObject target)
    {
        if (target == null) return;
        _target = target;
    }

    public virtual void ExecuteDebuff(IStatusEffect statusEffect) { }
    public virtual void RefreshDebuff() {}
    public virtual bool RemoveDebuff() { return false; }
    #endregion

    //public virtual void Activate(BaseProjectile ownProjectile) { } //<< Refactoring

    // public virtual void Deactivate(BaseProjectile ownProjectile) { } //<< Refactoring



    #region Default Recommended
    public void AddLevel()
    {
        if (_perkData.Level >= _perkData.MaxLevel)
        {
            Debug.Log("Достигнут Максимальный Уровень Перка");
        }
        else
        {
            _perkData.ChangeLevel(_perkData.Level + 1);
            InternalAddLevel();
        }
    }
    protected abstract void InternalAddLevel();

    public void RemoveLevel() //<< На Данный Момент Не Используется
    {
        if (_perkData.Level <= 0)
        {
            return;
        }
        else
        {
            _perkData.ChangeLevel(_perkData.Level - 1);
            InternalRemoveLevel();
        }
    }
    protected abstract void InternalRemoveLevel(); //<< На Данный Момент Не Используется
    #endregion
}