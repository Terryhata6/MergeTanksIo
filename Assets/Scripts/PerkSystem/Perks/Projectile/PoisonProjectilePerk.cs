using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonProjectile", menuName = "ScriptableObjects/PoisonProjectile", order = 1)]
public class PoisonProjectilePerk : BaseProjectilePerk
{
    [SerializeField] private float _durationDamage;
    [SerializeField] private float _damage;
    [SerializeField] private float _damagePerLevel;

    public override void ProjectileModification(BaseProjectile ownProjectile)
    {
        base.ProjectileModification(ownProjectile);
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