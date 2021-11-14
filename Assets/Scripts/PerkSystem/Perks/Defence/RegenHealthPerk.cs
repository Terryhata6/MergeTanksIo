// using UnityEngine;

// [CreateAssetMenu(fileName = "RegenHealth", menuName = "ScriptableObjects/RegenHealth", order = 1)]
// public class RegenHealthPerk : AbstractPerk
// {
//   [SerializeField] private float _regeneration = 1.0f;
//   [SerializeField] private float _delay = 1.0f;
//   private float _tempDelay = 0f;

//   private ViewParamsStruct _viewParams;
//   public override ViewParamsStruct Activate(ViewParamsStruct viewParams)
//   {
//     _viewParams = viewParams;

//     return _viewParams;
//   }

//   public override void UpdateFixedExecute(ViewParamsStruct viewParams)
//   {
//     _tempDelay += Time.deltaTime;
//     if (_tempDelay >= _delay)
//     {
//       if (_viewParams.Health < _viewParams.MaxHealth)
//       {
//         _viewParams.ChangeHealth(_viewParams.Health + _regeneration);
//       }
//       _tempDelay = 0f;
//     }
//   }

//   public override ViewParamsStruct Deactivate(ViewParamsStruct viewParams)
//   {
//     _regeneration = 1.0f;
//     _tempDelay = 0f;
//     return _viewParams;
//   }

//   protected override ViewParamsStruct InternalAddLevel()
//   {
//     _regeneration += 1.0f;
//     return _viewParams;
//   }

//   protected override ViewParamsStruct InternalRemoveLevel()
//   {
//     _regeneration -= 1.0f;
//     return _viewParams;
//   }
// }