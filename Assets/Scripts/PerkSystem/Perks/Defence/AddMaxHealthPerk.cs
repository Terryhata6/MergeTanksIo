using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddMaxHealth", menuName = "ScriptableObjects/AddMaxHealth", order = 1)]
public class AddMaxHealthPerk : AbstractPerk
{
  [SerializeField] private float _addHealth = 50f;

  public override void Activate(ViewParamsComponent viewParams)
  {
    _viewParams = viewParams;
    var newHealth = _viewParams.MaxHealth + _addHealth;
    _viewParams.ChangeMaxHealth(newHealth);
  }

  public override void Deactivate(ViewParamsComponent viewParams)
  {
    var newHealth = _viewParams.MaxHealth - _addHealth * _perkData.Level;
    _viewParams.ChangeMaxHealth(newHealth);
  }

  protected override void InternalAddLevel()
  {
    var newHealth = _viewParams.MaxHealth + _addHealth;
    _viewParams.ChangeMaxHealth(newHealth);
  }

  protected override void InternalRemoveLevel()
  {
    var newHealth = _viewParams.MaxHealth - _addHealth;
    _viewParams.ChangeMaxHealth(newHealth);
  }
}