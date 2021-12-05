using System.Collections.Generic;
using UnityEngine;

//Снаряды По Кругу
[CreateAssetMenu(fileName = "CircularProjectile", menuName = "ScriptableObjects/CircularProjectile", order = 1)]
public class CircularProjectilePerk : AbstractPerk
{
  [SerializeField] private int _count;
  [SerializeField] private float _radius;

  private GameObject _circleProjectile;
  private List<Projectile> _projectileList = new List<Projectile>();

  public override void Activate(Shooter ownShoot)
  {
    base.Activate(ownShoot);
    _ownShooter = ownShoot;
    //ownShoot.InitCircleProjectile(_count, _radius);
    CreateEmptyGameObject(ownShoot);
    AddToParent(ownShoot);
    PositioningInCircle(ownShoot, _radius);
    ownShoot.SetCircleProjectileWeapon(_circleProjectile);

  }

  protected override void InternalAddLevel()
  {
    // _ownShooter.AddProjectileForCircle(_count, _radius);
    //GetPooledProjectileFromParent(_ownShooter, _count, _radius);
    AddToParent(_ownShooter);
    PositioningInCircle(_ownShooter, _radius);
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }

  private void CreateEmptyGameObject(Shooter ownShoot)
  {
    _circleProjectile = new GameObject();
    _circleProjectile.name = "CircleProjectile_" + ownShoot.gameObject.name;
    _circleProjectile.transform.position = ownShoot.transform.position;
    _circleProjectile.transform.rotation = ownShoot.transform.rotation;

    // _circleProjectile.transform.parent = ownShoot.Pool.Parent.transform; // Парентим В Пулл Projectile
  }

  private void AddToParent(Shooter ownShoot)
  {
    var temporalProjectile = GetProjectileFromPool(ownShoot);
    AddProjectileToList(temporalProjectile);
    temporalProjectile.transform.parent = _circleProjectile.transform;
  }

  private void PositioningInCircle(Shooter ownShoot, float radius)
  {
    var angle = Mathf.PI / (_projectileList.Count / 2f);

    for (int i = 0; i < _projectileList.Count; i++)
    {
      var x = Mathf.Cos(angle * i) * radius;
      var z = Mathf.Sin(angle * i) * radius;
      
      var pos = _projectileList[i].transform.position = new Vector3(x,0,z) + ownShoot.transform.position;
    }
  }

  private Projectile GetProjectileFromPool(Shooter ownShoot)
  {
    var projectile = Resources.Load<Projectile>("Projectile");
    var inst = Instantiate(projectile);

    // var temporalProjectile = ownShoot.Pool.GetObject();
    // return temporalProjectile;

    return inst;
  }

  private void AddProjectileToList(Projectile projectile)
  {
    if (!_projectileList.Contains(projectile))
    {
      _projectileList.Add(projectile);
    }
  }
}