using System.Collections;
using System.Collections.Generic;
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
    _magnitude = Vector3.ClampMagnitude(_vectorMove2D, 100f).magnitude;


    _tempVector.x = _vectorMove2D.x;
    _tempVector.y = 0;
    _tempVector.z = _vectorMove2D.y;
    //<<Alt_Enter
    // Vector3 vectorDirection = new Vector3(_vectorMove2D.x, 1f, _vectorMove2D.y);
    // player.transform.rotation = Quaternion.Slerp(
    //   player.transform.rotation,
    //   Quaternion.LookRotation(vectorDirection),
    //   Time.deltaTime * player.ViewParams.RotationSpeed);
    // player.transform.position += player.transform.forward * Time.deltaTime * player.ViewParams.MoveSpeed;
    //>>END
    player.Rotation = Quaternion.LookRotation(_tempVector, Vector3.up);
    player.Transform.Translate(Vector3.forward * _magnitude * 0.01f * player.ViewParams.MoveSpeed * Time.deltaTime);
  }
}