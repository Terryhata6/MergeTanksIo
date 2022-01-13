using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Сквозные выстрелы (сквозь стены, конфликтует с рикошетом)
[CreateAssetMenu(fileName = "PenetrationShoot", menuName = "Perks/Projectile/PenetrationShoot", order = 1)]
public class PenetrationShootPerk : AbstractPerk
{

    [SerializeField] private int _penetrationCount;

    private PenetrationShootPerk()
    {
        _perkData.SetModBelongs(PerkType.ProjectileMod);
        _perkData.SetTypePerk(PerkType.Offence);
        _modificationType = TypeModification.Modification;
    }

    public override void ActivateModification(BaseProjectile ownProjectile)
    {
        base.ActivateModification(ownProjectile);
        if (ownProjectile.Target == null) return;
    }


    protected override void InternalAddLevel()
    {
        //TODO
    }

    protected override void InternalRemoveLevel()
    {
        //TODO
    }
}