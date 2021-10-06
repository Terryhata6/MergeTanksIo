using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : BaseController
{
  private List<Projectile> _listProjectiles;
  private PoolObjects _poolObjects;

  public override void Initialize ()
  {
    base.Initialize ();

    _poolObjects = GameObject.FindObjectOfType<PoolObjects>();
    _listProjectiles = _poolObjects.ListProjectile;
  }

  public override void Execute ()
  {
    base.Execute ();
    foreach (var item in _listProjectiles)
    {
        item.MoveProjectile();
    }
  }
}