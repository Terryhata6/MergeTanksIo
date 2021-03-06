using UnityEngine;

public class PlayerMoveStateModel : BasePlayerStateModel
{
  private Vector2 _vectorMove2D;
  private float _magnitude;
  private Vector3 _tempVector;

  public override void Execute(PlayerController controller, PlayerView player)
  {
    base.Execute(controller, player);

    //Move
    _vectorMove2D = controller.PositionDelta - controller.PositionBegan;


    _tempVector.x = _vectorMove2D.x;
    _tempVector.y = 0;
    _tempVector.z = _vectorMove2D.y;
    if (_tempVector.Equals(Vector3.zero))
        {
          return;
        }
    player.transform.rotation = Quaternion.Slerp(
      player.transform.rotation,
      Quaternion.LookRotation(_tempVector),
      Time.deltaTime * player.ViewParams.RotationSpeed);
    
    player.transform.position += player.transform.forward * Time.deltaTime * player.ViewParams.MoveSpeed;
  }
}