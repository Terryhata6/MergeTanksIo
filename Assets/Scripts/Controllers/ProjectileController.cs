using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : BaseController, IExecute
{
  private ObjectPool<Projectile> _pool;
  public ObjectPool<Projectile> Pool => _pool;
  private Projectile _projectile;
  private List<Shooter> _shotProjectileList = new List<Shooter>();

  private IProjectileModel _projectileModel;


  public override void Initialize()
  {
    base.Initialize();
    _projectile = Resources.Load<Projectile>("Projectile");

    _pool = new ObjectPool<Projectile>();
    _pool.Initialize(_projectile, 1000);

    _projectileModel = new BaseProjectileModel();
  }

  public override void Execute()
  {
    base.Execute();

    for (int i = 0; i < _shotProjectileList.Count; i++)
    {
      _shotProjectileList[i].MoveProjectile();

      _shotProjectileList[i].RotationCircleProjectile();

    }
  }

  public void AddShooterToList(Shooter shooter)
  {
    if (!_shotProjectileList.Contains(shooter))
    {
      _shotProjectileList.Add(shooter);
    }
  }
  public void RemoveShooterToList(Shooter shooter)
  {
    if (_shotProjectileList.Contains(shooter))
    {
      _shotProjectileList.Remove(shooter);
    }
  }
}