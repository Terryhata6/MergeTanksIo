using UnityEngine;

public class Projectile : BaseProjectile, IMoveProjectile
{
  private float _speed;
  private float _damage;


  private bool _lockMoved = false;
  public bool LockMoved => _lockMoved;

  public void Move()
  {
    if (!_lockMoved)
    {
      transform.Translate(transform.forward * (_speed * Time.deltaTime), Space.World);
    }
  }

  public void SetLockMoved(bool val)
  {
    _lockMoved = val;
  }

  public void ChangeSpeed(float speed)
  {
    _speed = speed;
  }

  public void ChangeDamage(float damage)
  {
    _damage = damage;
  }

  protected override void InternaTriggerEnter(Collider otherCollider)
  {
    foreach (var item in _modList)
    {
      item.Activate(this);
    }
  }
}