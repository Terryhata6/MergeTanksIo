using UnityEngine;


public abstract class AbstractPerk : ScriptableObject
{
    [SerializeField] protected PerkDataStruct _perkData;
    public PerkDataStruct PerkData => _perkData;

    [SerializeField][Tooltip("Перк Срабатывает при FixedUpdate")] protected bool _fixedExecute;
    public bool FixedExecute => _fixedExecute;
    public virtual void UpdateFixedExecute(ViewParamsStruct viewParams) {}

    protected Shooter _ownShooter;
    // protected Projectile _ownProjectile;

    public virtual ViewParamsStruct Activate(ViewParamsStruct viewParams) { return viewParams; }
    public virtual ViewParamsStruct Deactivate(ViewParamsStruct viewParams) { return viewParams; }


    public virtual void Activate(Shooter ownShoot) { }
    public virtual void Deactivate(Shooter ownShoot) { }

    // public virtual void Activate(Projectile ownProjectile, GameObject target) { }
    // public virtual void Activate(Projectile ownProjectile) { }


    
    // public virtual void Deactivate(Projectile ownProjectile) { }
    // public virtual void Deactivate(Projectile ownProjectile, GameObject target) { }



    public virtual ViewParamsStruct AddLevel(ViewParamsStruct viewParams)
    {
        if (_perkData.Level >= _perkData.MaxLevel)
        {
            Debug.Log("Достигнут Максимальный Уровень Перка");
            return viewParams;
        }
        else
        {
            _perkData.ChangeLevel(_perkData.Level + 1);
            return InternalAddLevel();
        }
    }
    protected abstract ViewParamsStruct InternalAddLevel();

    public virtual ViewParamsStruct RemoveLevel(ViewParamsStruct viewParams) //<< На Данный Момент Не Используется
    {
        if (_perkData.Level <= 0)
        {
            return viewParams;
        }
        else
        {
            _perkData.ChangeLevel(_perkData.Level - 1);
            return InternalRemoveLevel();
        }
    }
    protected abstract ViewParamsStruct InternalRemoveLevel(); //<< На Данный Момент Не Используется
}