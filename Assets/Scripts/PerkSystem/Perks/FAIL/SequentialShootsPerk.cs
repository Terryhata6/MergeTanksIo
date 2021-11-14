// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [CreateAssetMenu (fileName = "PerkSequentialShoots", menuName = "ScriptableObjects/SequentialShoots", order = 1)]
// public class SequentialShootsPerk : AbstractPerk
// {
//     private SequentialShootsPerk ()
//     {
//         _typePerk = PerkType.Offence;
//         _onEnable = true;
//     }

//     public override void Activate (Shooter ownShoot)
//     {

//         ownShoot.SetFlag (true);

//     }

//     public override void Deactivate (Shooter ownShoot)
//     {

//         ownShoot.SetFlag (false);

//     }


// }