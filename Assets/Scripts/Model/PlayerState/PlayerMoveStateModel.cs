using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveStateModel : BasePlayerStateModel
{
  private Vector2 _vectorMove2D;
  private float _magnitude;
  public override void Execute(PlayerController controller, PlayerView player)
  {
    //base.Execute(controller, player);

    //Move

    _vectorMove2D = controller.PositionDelta - controller.PositionBegan;
    _magnitude = _vectorMove2D.magnitude;

    if (_magnitude > 100)
    {
      _magnitude = 100.0f;
    }

    Vector3 vectorDirection = new Vector3(_vectorMove2D.x, 0, _vectorMove2D.y);
    player.Rotation = Quaternion.LookRotation(vectorDirection, Vector3.up);

    Vector3 trans = Vector3.forward * _magnitude * 0.02f * player.MovementSpeed * Time.deltaTime;
    player.Transform.Translate(trans);

  }
}
