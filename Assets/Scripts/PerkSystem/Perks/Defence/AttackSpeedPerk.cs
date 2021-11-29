using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "ScriptableObjects/AttackSpeed", order = 1)]
public class AttackSpeedPerk : AbstractPerk
{
  [SerializeField] private float _speed = 10f; //<< Percentag
  private float _tempPrecentage;

  public override void Activate(Shooter ownShoot)
  {
    _ownShooter = ownShoot;

    float newSpeed = AttackSpeed(ownShoot.ShootInterval);
    ownShoot.ChangeShootInterval(newSpeed);

  }


  public override void Deactivate(Shooter ownShoot)
  {
    float newSpeed = ownShoot.ShootInterval + _tempPrecentage * PerkData.Level;

    ownShoot.ChangeShootInterval(newSpeed);

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