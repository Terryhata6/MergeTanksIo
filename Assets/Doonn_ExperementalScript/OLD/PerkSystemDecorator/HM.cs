using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Рикошет
[CreateAssetMenu (fileName = "RicochetPerk", menuName = "ScriptableObjects/Ricochet", order = 1)]
public class HM : AbstractDecorator
{
   private HM ()
   {
      _typePerk = PerkType.Offence;
      _onEnable = true;
   }

   public override void Activate (Shooter shoot)
   {
      foreach (var item in shoot.ProjectileList)
      {
         //item.SetRicochet (true, 4);
      }
   }

   public override Projectile Active (Projectile projectile, GameObject target)
   {
      SetProjectile (projectile);
      SetTarget (target);
      return Ricoshet (projectile, target);
   }

   public Projectile Ricoshet (Projectile projectile, GameObject target)
   {
      Ray ray = new Ray (projectile.transform.position, projectile.transform.forward);
      RaycastHit hit;
      
      if (Physics.Raycast (ray, out hit))
      {
         projectile.transform.forward = Vector3.Reflect (projectile.transform.forward, hit.normal);
         projectile.transform.position = hit.point;
         return projectile;
      }
      else
      {
         projectile.transform.position += projectile.transform.forward;
         return projectile;
      }

   }

   protected override GameObject SetTarget (GameObject target)
   {
      return _wrappedTarget = target;
   }
   protected override Projectile SetProjectile (Projectile projectile)
   {
      return _wrappedProjectile = projectile;
   }
}
