using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSize", menuName = "Perks/Projectile/ProjectileSize", order = 1)]
public class ProjectileSizePerk : AbstractPerk
{
  [SerializeField] private float _size;
  [SerializeField] private float _sizePerLevel;


  private ProjectileSizePerk()
  {
    _perkData.SetModBelongs(PerkType.ProjectileMod);
    _perkData.SetTypePerk(PerkType.Offence);
    _modificationType = TypeModification.Modification;
  }
  
  public override void ActivateModification(BaseProjectile projectile)
  {
    base.ActivateModification(projectile);

    projectile.transform.localScale += new Vector3(_size, _size, _size);

  }

  // public override void Deactivate(BaseProjectile projectile)
  // {
  //   // TODO
  // }

  protected override void InternalAddLevel()
  {
    _size += _sizePerLevel;
  }

  protected override void InternalRemoveLevel()
  {
    _size -= _sizePerLevel;
  }
}