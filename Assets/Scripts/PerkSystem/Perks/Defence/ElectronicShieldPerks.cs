using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElectronicShield", menuName = "Perks/ViewParams/ElectronicShield", order = 1)]
public class ElectronicShieldPerks : AbstractPerk
{
  [SerializeField] private float _shield = 100f;

  private ElectronicShieldPerks()
  {
    _perkData.SetModBelongs(PerkType.ViewParamsMod);
    _perkData.SetTypePerk(PerkType.Defence);
  }
  
  public override void Activate(ViewParamsComponent viewParams)
  {
    if(viewParams == null) return;
    base.Activate(viewParams);
    _ownViewParams = viewParams;
    viewParams.ChangeShield(viewParams.Shield + _shield);
  }

  public override void Deactivate(ViewParamsComponent viewParams)
  {
    viewParams.ChangeShield(viewParams.Shield - _shield * PerkData.Level);
  }

  protected override void InternalAddLevel()
  {
    _ownViewParams.ChangeShield(_ownViewParams.Shield + _shield);
  }

  protected override void InternalRemoveLevel()
  {
    _ownViewParams.ChangeShield(_ownViewParams.Shield - _shield);
  }
}