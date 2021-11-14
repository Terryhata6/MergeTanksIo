using UnityEngine;

public enum PerkType
{
    Defence,
    Offence
}

public abstract class AbstractPerk : ScriptableObject
{
    [SerializeField] protected PerkDataStruct _perkData;
    public PerkDataStruct PerkData => _perkData;

    [SerializeField][Tooltip("Перк Срабатывает при FixedUpdate")] protected bool _fixedExecute;
    public bool FixedExecute => _fixedExecute;
    public virtual void UpdateFixedExecute(ViewParamsComponent viewParams) { }
    protected ViewParamsComponent _viewParams;
    protected Shooter _ownShooter;
    // protected Projectile _ownProjectile;

    public virtual void Activate(ViewParamsComponent viewParams) { }
    public virtual void Deactivate(ViewParamsComponent viewParams) { }


    public virtual void Activate(Shooter ownShoot) { }
    public virtual void Deactivate(Shooter ownShoot) { }

    // public virtual void Activate(Projectile ownProjectile, GameObject target) { }
    public virtual void Activate(Projectile ownProjectile) { }  //<< ХММММ Видимо Плохое Решение



    public virtual void Deactivate(Projectile ownProjectile) { } //<< ХММММ Видимо Плохое Решение
    // public virtual void Deactivate(Projectile ownProjectile, GameObject target) { }



    public virtual void AddLevel()
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

    public virtual void RemoveLevel() //<< На Данный Момент Не Используется
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
}