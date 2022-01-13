using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonProjectile", menuName = "Perks/Projectile/PoisonProjectile", order = 1)]
public class PoisonProjectilePerk : AbstractPerk
{
    [SerializeField] public float _durationDamage;
    [SerializeField] private float _periodDamage;
    [SerializeField] private float _damage;
    [SerializeField] private float _damagePerLevel;
    public float _tempTime = 0f;
    public float _passedTime = 0f;

    private PoisonProjectilePerk()
    {
        _perkData.SetModBelongs(PerkType.ProjectileMod);
        _perkData.SetTypePerk(PerkType.Offence);
        _modificationType = TypeModification.Debuff;
    }

    public override void ExecuteDebuff(IStatusEffect statusEffect)
    {
        base.ExecuteDebuff(statusEffect);
        _tempTime += Time.deltaTime;
        if (_tempTime >= _periodDamage)
        {
            statusEffect.TakeDamage(_damage / _durationDamage * _periodDamage);
            _passedTime += _tempTime;
            _tempTime = 0f;
        }
    }

    public override void RefreshDebuff()
    {
        _passedTime = 0f;
        _tempTime = 0f;
    }

    public override bool RemoveDebuff()
    {
        base.RemoveDebuff();
        if (_passedTime >= _durationDamage)
        {
            _passedTime = 0f;
            _tempTime = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override void InternalAddLevel()
    {
        _damage += _damagePerLevel;
    }

    protected override void InternalRemoveLevel()
    {
        _damage -= _damagePerLevel;
    }
}