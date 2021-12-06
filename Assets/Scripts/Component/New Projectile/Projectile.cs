using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseProjectile, IMoveProjectile
{
  private float _speed;
  private float _damage;
  private BasePersonView _owner;

  public void SetOwner(BasePersonView view)
  {
    _owner = view;
  }

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
    for (int i = 0 ; i < _modList.Count; i++)
    {
      _modList[i].Activate(this);
    }
  }
}