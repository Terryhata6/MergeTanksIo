using UnityEngine;

//Рикошет
[CreateAssetMenu(fileName = "Ricochet", menuName = "Perks/Projectile/Ricochet", order = 1)]
public class RicochetPerk : AbstractPerk
{

  private RicochetPerk()
  {
    _perkData.SetModBelongs(PerkType.ProjectileMod);
    _perkData.SetTypePerk(PerkType.Offence);
    _modificationType = TypeModification.Modification;
  }

  public override void ActivateModification(BaseProjectile ownProjectile)
  {
    base.ActivateModification(ownProjectile);
    ownProjectile.SetRicoshetIsActive(true);
  }
  public override void ActivateHit(BaseProjectile ownProjectile, GameObject target)
  {
    base.ActivateHit(ownProjectile, target);
    Ricoshet(ownProjectile);
  }

  public void Ricoshet(BaseProjectile projectile)
  {
    //projectile.transform.forward -= projectile.transform.forward;
    Ray ray = new Ray(projectile.transform.position, projectile.transform.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
      projectile.transform.forward = Vector3.Reflect(projectile.transform.forward, hit.normal);
      projectile.transform.position = hit.point;
    }
    else
    {
      projectile.transform.position += projectile.transform.forward;
    }
  }

  protected override void InternalAddLevel()
  {
    // TODO
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}