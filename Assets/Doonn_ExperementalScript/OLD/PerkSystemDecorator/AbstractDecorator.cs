using UnityEngine;

public abstract class AbstractDecorator : AbstractPerk
{
  protected AbstractPerk _wrappedEntity;
  protected Projectile _wrappedProjectile;

  protected GameObject _wrappedTarget;


  protected virtual Projectile SetProjectile (Projectile projectile)
  {
    _wrappedProjectile = projectile;
    return _wrappedProjectile;
  }

  protected virtual GameObject SetTarget (GameObject target)
  {
    _wrappedTarget = target;
    return _wrappedTarget;
  }

  public virtual Projectile Active (Projectile projectile, GameObject target)
  {
    return Active (projectile, target);
  }

}