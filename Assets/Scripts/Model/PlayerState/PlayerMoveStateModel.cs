
using UnityEngine;

public class PlayerMoveStateModel : BasePlayerStateModel
{
  private Vector2 _vectorMove2D;
  private float _magnitude;
  public override void Execute(PlayerController controller, PlayerView player)
  {
    base.Execute(controller, player);

    //Move
    _vectorMove2D = controller.PositionDelta - controller.PositionBegan;

    Vector3 vectorDirection = new Vector3(_vectorMove2D.x, 0f, _vectorMove2D.y);
    if (vectorDirection.Equals(Vector3.zero))
    {
      return;
    }
    player.transform.rotation = Quaternion.Slerp(
      player.transform.rotation,
      Quaternion.LookRotation(vectorDirection), 
      Time.deltaTime * player.ViewParams.RotationSpeed);
    player.transform.position += player.transform.forward * Time.deltaTime * player.ViewParams.MoveSpeed;

  }
}
