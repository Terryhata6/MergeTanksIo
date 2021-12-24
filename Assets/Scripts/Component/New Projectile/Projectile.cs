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

  protected override void InternalTriggerEnter(Collider otherCollider)
  {
    if (otherCollider.TryGetComponent(out IApplyDamage applyDamage))
    {
      // Debug.Log("Попал");
      // if (_damage <= 0) return;
      // applyDamage.TakeDamage(_damage);
    }
  }
}