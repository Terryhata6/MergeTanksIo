using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "Perks/Shooter/AttackSpeed", order = 1)]
public class AttackSpeedPerk : AbstractPerk
{
  [SerializeField] private float _speed = 10f; //<< Percentag
  private float _tempPrecentage;

  private AttackSpeedPerk()
  {
    _perkData.SetModBelongs(PerkType.WeaponMod);
    _perkData.SetTypePerk(PerkType.Defence);
  }

  public override void Activate(Shooter ownShooter)
  {
    if(ownShooter == null) return;
    base.Activate(ownShooter);
    float newSpeed = AttackSpeed(ownShooter.ShootInterval);
    ownShooter.ChangeShootInterval(newSpeed);

  }


  public override void Deactivate(Shooter ownShooter)
  {
    float newSpeed = ownShooter.ShootInterval + _tempPrecentage * PerkData.Level;

    ownShooter.ChangeShootInterval(newSpeed);

  }

  private float AttackSpeed(float speed)
  {
    _tempPrecentage = (speed / 100) * _speed;

    return speed -= _tempPrecentage;
  }

  protected override void InternalAddLevel()
  {
    float newSpeed = AttackSpeed(_ownShooter.ShootInterval);
    _ownShooter.ChangeShootInterval(newSpeed);
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}