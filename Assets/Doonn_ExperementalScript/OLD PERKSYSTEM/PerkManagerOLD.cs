// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;

// [Serializable]
// public class PerkManagerOLD
// {
//     [SerializeField] private List<AbstractPerk> _playerPerkList = new List<AbstractPerk>();
//     public List<AbstractPerk> PlayerPerkList => _playerPerkList;
//     [SerializeField] private List<AbstractPerk> _shooterPerkList = new List<AbstractPerk>();
//     public List<AbstractPerk> ShooterPerkList => _shooterPerkList;

//     private PlayerView _player;
//     private Shooter _shooter;

//     public PerkManagerOLD(PlayerView player, Shooter shooter)
//     {
//         _player = player;
//         _shooter = shooter;
//     }
   
//     public void AddPerk(AbstractPerk perk)
//     {
//         switch (perk.TypePerk)
//         {
//             case PerkType.Defence:
//                 if (PlayerMatchingPerk(perk))
//                 {
//                     _playerPerkList.Add(perk);
//                     perk.Activate(_player);
//                     if (perk.FixedExecute)
//                     {
//                         _player.ExecutablePerks += perk.Activate;
//                     }
//                 }
//                 else
//                 {
//                     foreach (var playerPerk in _playerPerkList)
//                     {
//                         playerPerk.AddLevel();
//                     }
//                 }
//                 break;

//             case PerkType.Offence:

//                 if (ShooterMatchingPerk(perk))
//                 {
//                     _shooterPerkList.Add(perk);
//                     perk.Activate(_shooter);
//                 }
//                 else
//                 {
//                     foreach (var shooterPerk in _shooterPerkList)
//                     {
//                         shooterPerk.AddLevel();
//                     }
//                 }
//                 break;
//         }
//         CheckShooterPerkListPriority();
//     }

//     private void CheckShooterPerkListPriority()
//     {
//         if (_shooterPerkList == null || _shooterPerkList.Count < 2) return;

//         //Sort List a Priority
//         _shooterPerkList = _shooterPerkList.OrderBy(x => x.Priority).ToList();
//     }

//     public void RemovePlayerPerk(AbstractPerk perk)
//     {
//         _playerPerkList.Remove(perk);
//         perk.Deactivate(_player);

//         if (perk.FixedExecute)
//         {
//             _player.ExecutablePerks -= perk.Activate;
//         }
//     }

//     public void RemoveShooterPerk(AbstractPerk perk)
//     {
//         _shooterPerkList.Remove(perk);
//         perk.Deactivate(_shooter);

//         if (perk.FixedExecute)
//         {
//             _player.ExecutablePerks -= perk.Activate;
//         }
//     }

//     private bool ShooterMatchingPerk(AbstractPerk perk)
//     {
//         foreach (var shooterPerk in _shooterPerkList)
//         {
//             if (shooterPerk.GetType() == perk.GetType())
//             {
//                 return false;
//             }
//         }
//         return true;
//     }

//     private bool PlayerMatchingPerk(AbstractPerk perk)
//     {
//         foreach (var playerPerk in _playerPerkList)
//         {
//             if (playerPerk.GetType() == perk.GetType())
//             {
//                 return false;
//             }
//         }
//         return true;
//     }
// }