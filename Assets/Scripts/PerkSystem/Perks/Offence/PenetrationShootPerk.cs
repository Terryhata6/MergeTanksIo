using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Сквозные выстрелы (сквозь стены, конфликтует с рикошетом)
[CreateAssetMenu(fileName = "PenetrationShoot", menuName = "ScriptableObjects/PenetrationShoot", order = 1)]
public class PenetrationShootPerk : AbstractPerk
{

    [SerializeField] private int _penetrationCount;
    public override void Activate(BaseProjectile ownProjectile)
    {
        base.Activate(ownProjectile);
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