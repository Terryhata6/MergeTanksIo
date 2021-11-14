using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddMaxHealth", menuName = "ScriptableObjects/AddMaxHealth", order = 1)]
public class AddMaxHealthPerk : AbstractPerk
{
  [SerializeField] private float _addHealth = 50f;
  private ViewParamsStruct _viewParams;

  public override ViewParamsStruct Activate(ViewParamsStruct viewParams)
  {
    _viewParams = viewParams;
    var newHealth = _viewParams.MaxHealth + _addHealth;
    _viewParams.ChangeMaxHealth(newHealth);
    return _viewParams;
  }

  public override ViewParamsStruct Deactivate(ViewParamsStruct viewParams)
  {
    var newHealth = _viewParams.MaxHealth - _addHealth * _perkData.Level;
    _viewParams.ChangeMaxHealth(newHealth);
    return _viewParams;
  }

  protected override ViewParamsStruct InternalAddLevel()
  {
    var newHealth = _viewParams.MaxHealth + _addHealth;
    _viewParams.ChangeMaxHealth(newHealth);
    return _viewParams;
  }

  protected override ViewParamsStruct InternalRemoveLevel()
  {
    var newHealth = _viewParams.MaxHealth - _addHealth;
    _viewParams.ChangeMaxHealth(newHealth);
    return _viewParams;
  }
}