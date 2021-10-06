using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : BaseController
{
  private List<Projectile> _listProjectiles;
  private ObjectPool<Projectile> _pool;
  private ShotProjectile _shotProjectile;
  
  public override void Initialize ()
  {
    base.Initialize ();
    _shotProjectile = GameObject.FindObjectOfType<ShotProjectile>();
    
    Projectile projectile = Resources.Load<Projectile> ("Projectile");
    
    _pool = new ObjectPool<Projectile>();

    _pool.Initialize(projectile, 100);

    _shotProjectile.SetObjectPools(_pool);
  }

  public override void Execute ()
  {
    base.Execute ();
  }
}