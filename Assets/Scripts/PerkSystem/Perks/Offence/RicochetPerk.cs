using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Рикошет
[CreateAssetMenu(fileName = "RicochetPerk", menuName = "ScriptableObjects/Ricochet", order = 1)]
public class RicochetPerk : AbstractPerk
{
  public override void Activate(Projectile projectile, GameObject target)
  {
    Ricoshet(projectile, target);
  }

  public void Ricoshet(Projectile projectile, GameObject target)
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