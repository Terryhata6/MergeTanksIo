using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PerkSequentialShoots", menuName = "ScriptableObjects/PerkSequentialShoots", order = 1)]
public class PerkSequentialShoots : AbstractPerk
{

    public override void Activate (Shooter ownShoot)
    {

        ownShoot.SetFlag(true);

    }


}