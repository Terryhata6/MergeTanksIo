using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseProjectile, IMoveProjectile
{
  private float _speed;
  private float _damage;

  public void Move()
  {
    transform.Translate(transform.forward * (_speed * Time.deltaTime), Space.World);
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