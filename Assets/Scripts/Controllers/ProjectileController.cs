using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : BaseController
{
  private ObjectPool<Projectile> _pool;
  public ObjectPool<Projectile> Pool => _pool;
  private Projectile _projectile;
  private List<Shooter> _shotProjectileList = new List<Shooter> ();
  private List<Projectile> _projectileList = new List<Projectile> ();


  public override void Initialize ()
  {
    base.Initialize ();
    _projectile = Resources.Load<Projectile> ("Projectile");

    _pool = new ObjectPool<Projectile> ();
    _pool.Initialize (_projectile, 100f);
  }

  public override void Execute ()
  {
    base.Execute ();
     
    foreach (var shooter in _shotProjectileList)
    {
      foreach (var projectile in shooter.ProjectileList)
      {
        projectile.MoveProjectile ();
      }
    }
  }

  public void AddShooterToList (Shooter shooter)
  {
    if (!_shotProjectileList.Contains (shooter))
    {
      _shotProjectileList.Add (shooter);
    }
  }
  public void RemoveShooterToList (Shooter shooter)
  {
    if (_shotProjectileList.Contains (shooter))
    {
      _shotProjectileList.Remove (shooter);
    }
  }
}