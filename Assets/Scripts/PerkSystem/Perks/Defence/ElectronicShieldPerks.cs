using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElectronicShield", menuName = "ScriptableObjects/ElectronicShield", order = 1)]
public class ElectronicShieldPerks : AbstractPerk
{
  [SerializeField] private float _shield = 100f;
  
  public override void Activate(ViewParamsComponent viewParams)
  {
    base.Activate(viewParams);
    _viewParams = viewParams;
    _viewParams.ChangeShield(_viewParams.Shield + _shield);
  }

  public override void Deactivate(ViewParamsComponent viewParams)
  {
    viewParams.ChangeShield(viewParams.Shield - _shield * PerkData.Level);
  }

  protected override void InternalAddLevel()
  {
    _viewParams.ChangeShield(_viewParams.Shield + _shield);
  }

  protected override void InternalRemoveLevel()
  {
    _viewParams.ChangeShield(_viewParams.Shield - _shield);
  }
}