using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElectronicShield", menuName = "ScriptableObjects/ElectronicShield", order = 1)]
public class ElectronicShieldPerks : AbstractPerk
{
  [SerializeField] private float _shield = 100f;
  private ViewParamsStruct _viewParams;
  public override ViewParamsStruct Activate(ViewParamsStruct viewParams)
  {
    _viewParams = viewParams;
    _viewParams.ChangeShield(viewParams.Shield + _shield);
    return _viewParams;
  }

  public override ViewParamsStruct Deactivate(ViewParamsStruct viewParams)
  {
    viewParams.ChangeShield(viewParams.Shield - _shield * PerkData.Level);
    return viewParams;
  }

  protected override ViewParamsStruct InternalAddLevel()
  {
    _viewParams.ChangeShield(_viewParams.Shield + _shield);
    return _viewParams;
  }

  protected override ViewParamsStruct InternalRemoveLevel()
  {
    _viewParams.ChangeShield(_viewParams.Shield - _shield);
    return _viewParams;
  }
}