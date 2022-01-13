using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeed", menuName = "Perks/ViewParams/MoveSpeed", order = 1)]
public class MoveSpeedPerk : AbstractPerk
{
  [SerializeField] private float _speed = 10f; //<< Percentag
  private float _tempPrecentage;

  private MoveSpeedPerk()
  {
    _perkData.SetModBelongs(PerkType.ViewParamsMod);
    _perkData.SetTypePerk(PerkType.Defence);
  }

  public override void Activate(ViewParamsComponent ownPlayer)
  {
    _ownViewParams = ownPlayer;

    float newSpeed = AddMoveSpeed(_ownViewParams.MoveSpeed);
    _ownViewParams.ChangeMoveSpeed(newSpeed);
  }

  private float AddMoveSpeed(float speed)
  {
    _tempPrecentage = (speed / 100) * _speed;

    return speed += _tempPrecentage;
  }

  // BUG  
  public override void Deactivate(ViewParamsComponent ownPlayer)
  {
    float newSpeed = ownPlayer.MoveSpeed - _tempPrecentage * _perkData.Level;
    ownPlayer.ChangeMoveSpeed(newSpeed);
  }

  protected override void InternalAddLevel()
  {
    float newSpeed = AddMoveSpeed(_ownViewParams.MoveSpeed);
    _ownViewParams.ChangeMoveSpeed(newSpeed);
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}