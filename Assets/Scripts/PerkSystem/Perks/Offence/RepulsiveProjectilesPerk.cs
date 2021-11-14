// using UnityEngine;

// //Отталкивающие снаряды
// [CreateAssetMenu(fileName = "RepulsiveProjectilesPerk", menuName = "ScriptableObjects/RepulsiveProjectiles", order = 1)]
// public class RepulsiveProjectilesPerk : AbstractPerk
// {
//   [SerializeField] private float _distance;

//   private RepulsiveProjectilesPerk()
//   {
//     _typePerk = PerkType.Offence;
//     _onEnable = true;
//     _distance = 1f;
//     _fixedExecute = false;
//     _maxLevel = 5;
//     _priority = 0;
//   }

//   public override void Activate(Projectile ownProjectile, GameObject target)
//   {
//     Repulsive(ownProjectile, target);
//   }

//   public Vector3 Repulsive(Projectile projectile, GameObject target)
//   {
//     return target.transform.position += (projectile.transform.forward * _distance);
//   }

//   public override void Deactivate(Projectile ownProjectile, GameObject target)
//   {
//     // TODO
//   }

//   protected override void InternalAddLevel()
//   {
//     _distance++;
//   }

//   protected override void InternalRemoveLevel()
//   {
//     // TODO
//   }
// }