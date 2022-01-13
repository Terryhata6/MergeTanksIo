using UnityEngine;

[CreateAssetMenu(fileName = "RegenHealth", menuName = "Perks/ViewParams/RegenHealth", order = 1)]
public class RegenHealthPerk : AbstractPerk
{
  [SerializeField] private float _regeneration = 1.0f;
  [SerializeField] private float _delay = 1.0f;
  private float _tempDelay = 0f;

  private RegenHealthPerk()
  {
    _perkData.SetModBelongs(PerkType.ViewParamsMod);
    _perkData.SetTypePerk(PerkType.Defence);
    _perkData.SetPerkEffect(PerkDataStruct.PerkEffect.Buff);
    _isActiveBuff = true;
  }

  public override void Activate(ViewParamsComponent ownViewParams)
  {
    base.Activate(ownViewParams);
  }

  public override void ActivateBuff(ViewParamsComponent ownViewParams)
  {
    _tempDelay += Time.deltaTime;
    if (_tempDelay >= _delay)
    {
      if (_ownViewParams.Health < _ownViewParams.MaxHealth)
      {
        _ownViewParams.ChangeHealth(_ownViewParams.Health + _regeneration);
      }
      _tempDelay = 0f;
    }
  }

  public override void Deactivate(ViewParamsComponent viewParams)
  {
    _regeneration = 1.0f;
    _tempDelay = 0f;
  }

  protected override void InternalAddLevel()
  {
    _regeneration += 1.0f;
  }

  protected override void InternalRemoveLevel()
  {
    _regeneration -= 1.0f;
  }
}