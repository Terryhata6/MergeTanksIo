using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Рикошет
[CreateAssetMenu(fileName = "RicochetPerk", menuName = "ScriptableObjects/Ricochet", order = 1)]
public class RicochetPerk : AbstractPerk
{
  public override void Activate(BaseProjectile projectile)
  {
    _ownProjectile = projectile;
    Intercat(projectile.Target);
    //Ricoshet(projectile);
  }
  private void Intercat(GameObject target) {
    if(target == null) return;
    Ricoshet(_ownProjectile);
  }

  public void Ricoshet(BaseProjectile projectile)
  {
    Ray ray = new Ray(projectile.transform.position, projectile.transform.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
      projectile.transform.forward = Vector3.Reflect(projectile.transform.forward, hit.normal);
      projectile.transform.position = hit.point;
    }
    else
    {
      projectile.transform.position += projectile.transform.forward;
    }
  }

  protected override void InternalAddLevel()
  {
    // TODO
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}