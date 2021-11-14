// using UnityEngine;

// [CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/MoveSpeed", order = 1)]
// public class MoveSpeedPerk : AbstractPerk
// {
//   [SerializeField] private float _speed = 10f; //<< Percentag
//   private float _tempPrecentage;
//   private ViewParamsStruct _viewParams;

//   public override ViewParamsStruct Activate(ViewParamsStruct ownPlayer)
//   {
//     _viewParams = ownPlayer;

//     float newSpeed = AddMoveSpeed(_viewParams.MoveSpeed);
//     _viewParams.ChangeMoveSpeed(newSpeed);
//     return _viewParams;
//   }

//   private float AddMoveSpeed(float speed)
//   {
//     _tempPrecentage = (speed / 100) * _speed;

//     return speed += _tempPrecentage;
//   }

//   // BUG  
//   public override ViewParamsStruct Deactivate(ViewParamsStruct ownPlayer)
//   {
//     float newSpeed = ownPlayer.MoveSpeed - _tempPrecentage * _perkData.Level;
//     ownPlayer.ChangeMoveSpeed(newSpeed);
//     return ownPlayer;
//   }

//   protected override ViewParamsStruct InternalAddLevel()
//   {
//     float newSpeed = AddMoveSpeed(_viewParams.MoveSpeed);
//     _viewParams.ChangeMoveSpeed(newSpeed);
//     return _viewParams;
//   }

//   protected override ViewParamsStruct InternalRemoveLevel()
//   {
//     return _viewParams;
//   }
// }