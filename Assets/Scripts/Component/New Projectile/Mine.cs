using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : BaseProjectile
{
  private float _damage;

  public void ChangeDamage(float damage)
  {
    _damage = damage;
  }
  
  protected override void InternaTriggerEnter(Collider otherCollider)
  {
    // TODO
  }
}