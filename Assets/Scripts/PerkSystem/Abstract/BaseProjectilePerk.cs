using UnityEngine;

public abstract class BaseProjectilePerk : AbstractPerk
{
    public virtual void ProjectileModification(BaseProjectile ownProjectile) { }
}