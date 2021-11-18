using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSize", menuName = "ScriptableObjects/ProjectileSize", order = 1)]
public class ProjectileSizePerk : AbstractPerk
{
  [SerializeField] float _size;

  public override void Activate(Projectile projectile)
  {
    _ownProjectile = projectile;

    projectile.gameObject.transform.localScale += new Vector3(_size, _size, _size);

  }

  public override void Deactivate(Projectile projectile)
  {
    // TODO
  }

  protected override void InternalAddLevel()
  {
    _size += 0.1f;
  }

  protected override void InternalRemoveLevel()
  {
    _size -= 0.1f;
  }
}