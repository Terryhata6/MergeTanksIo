using UnityEngine;

[CreateAssetMenu(fileName = "RegenHealth", menuName = "ScriptableObjects/RegenHealth", order = 1)]
public class RegenHealthPerk : AbstractPerk
{
  [SerializeField] private float _regeneration = 1.0f;
  [SerializeField] private float _delay = 1.0f;
  private float _tempDelay = 0f;

  public override void Activate(ViewParamsComponent viewParams)
  {
    _viewParams = viewParams;
  }

  public override void UpdateFixedExecute(ViewParamsComponent viewParams)
  {
    _tempDelay += Time.deltaTime;
    if (_tempDelay >= _delay)
    {
      if (_viewParams.Health < _viewParams.MaxHealth)
      {
        _viewParams.ChangeHealth(_viewParams.Health + _regeneration);
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