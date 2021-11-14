using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/MoveSpeed", order = 1)]
public class MoveSpeedPerk : AbstractPerk
{
  [SerializeField] private float _speed = 10f; //<< Percentag
  private float _tempPrecentage;

  public override void Activate(ViewParamsComponent ownPlayer)
  {
    _viewParams = ownPlayer;

    float newSpeed = AddMoveSpeed(_viewParams.MoveSpeed);
    _viewParams.ChangeMoveSpeed(newSpeed);
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
    float newSpeed = AddMoveSpeed(_viewParams.MoveSpeed);
    _viewParams.ChangeMoveSpeed(newSpeed);
  }

  protected override void InternalRemoveLevel()
  {
    // TODO
  }
}