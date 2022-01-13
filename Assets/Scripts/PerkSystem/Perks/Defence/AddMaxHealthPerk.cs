using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddMaxHealth", menuName = "Perks/ViewParams/AddMaxHealth", order = 1)]
public class AddMaxHealthPerk : AbstractPerk
{
  [SerializeField] private float _addHealth = 50f;

  private AddMaxHealthPerk()
  {
    _perkData.SetModBelongs(PerkType.ViewParamsMod);
    _perkData.SetTypePerk(PerkType.Defence);
  }

  public override void Activate(ViewParamsComponent viewParams)
  {
    _ownViewParams = viewParams;
    var newHealth = _ownViewParams.MaxHealth + _addHealth;
    _ownViewParams.ChangeMaxHealth(newHealth);
  }

  public override void Deactivate(ViewParamsComponent viewParams)
  {
    var newHealth = _ownViewParams.MaxHealth - _addHealth * _perkData.Level;
    _ownViewParams.ChangeMaxHealth(newHealth);
  }

  protected override void InternalAddLevel()
  {
    var newHealth = _ownViewParams.MaxHealth + _addHealth;
    _ownViewParams.ChangeMaxHealth(newHealth);
  }

  protected override void InternalRemoveLevel()
  {
    var newHealth = _ownViewParams.MaxHealth - _addHealth;
    _ownViewParams.ChangeMaxHealth(newHealth);
  }
}