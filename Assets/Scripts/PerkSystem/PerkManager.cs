using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PerkManager
{
  [SerializeField] private List<AbstractPerk> _ownPlayerPerkList = new List<AbstractPerk>();
  public List<AbstractPerk> OwnPlayerPerkList => _ownPlayerPerkList;
  [SerializeField] private List<AbstractPerk> _ownShooterPerkList = new List<AbstractPerk>();
  public List<AbstractPerk> OwnShooterPerkList => _ownShooterPerkList;

  private ViewParamsComponent _ownViewParams;
  private Shooter _shooter;

  public PerkManager(ViewParamsComponent ownViewParams)
  {
    _ownViewParams = ownViewParams;
  }

  public PerkManager(ViewParamsComponent ownViewParams, Shooter shooter)
  {
    _ownViewParams = ownViewParams;
    _shooter = shooter;
  }

  public ViewParamsComponent UpdateViewParamsStruct()
  {
    return _ownViewParams;
  }

  public void AddPerk(AbstractPerk perk)
  {
    switch (perk.PerkData.TypePerk)
    {
      case PerkType.Defence:
        if (PlayerMatchingPerk(perk))
        {
          _ownPlayerPerkList.Add(perk);
          perk.Activate(_ownViewParams);
          if (perk.FixedExecute)
          {
            ExecutablePerks += perk.UpdateFixedExecute;
          }
        }
        else
        {
          foreach (var ownPlayerPerk in _ownPlayerPerkList)
          {
            ownPlayerPerk.AddLevel();
          }
        }
        break;
      case PerkType.Offence:
        if (ShooterMatchingPerk(perk))
        {
          _ownShooterPerkList.Add(perk);
          perk.Activate(_shooter);
        }
        else
        {
          foreach (var shooterPerk in _ownShooterPerkList)
          {
            shooterPerk.AddLevel();
          }
        }
        break;
    }
    CheckShooterPerkListPriority();
  }

  private bool PlayerMatchingPerk(AbstractPerk perk)
  {
    foreach (var playerPerk in _ownPlayerPerkList)
    {
      if (playerPerk.GetType() == perk.GetType())
      {
        return false;
      }
    }
    return true;
  }

  public void RemovePlayerPerk(AbstractPerk perk)
  {
    _ownPlayerPerkList.Remove(perk);
    perk.Deactivate(_ownViewParams);

    if (perk.FixedExecute)
    {
      ExecutablePerks -= perk.UpdateFixedExecute;
    }
  }

  private bool ShooterMatchingPerk(AbstractPerk perk)
  {
    foreach (var shooterPerk in _ownShooterPerkList)
    {
      if (shooterPerk.GetType() == perk.GetType())
      {
        return false;
      }
    }
    return true;
  }



  private void CheckShooterPerkListPriority()
  {
    if (_ownShooterPerkList == null || _ownShooterPerkList.Count < 2) return;

    //Sort List a Priority
    _ownShooterPerkList = _ownShooterPerkList.OrderBy(x => x.PerkData.Priority).ToList();
  }



  public void RemoveShooterPerk(AbstractPerk perk)
  {
    _ownShooterPerkList.Remove(perk);
    perk.Deactivate(_shooter);

    if (perk.FixedExecute)
    {
      //ExecutablePerks -= perk.UpdateFixedExecute;
    }
  }



  #region Events Perk FixedExecute is True
  public event Action<ViewParamsComponent> ExecutablePerks;
  public void ExecutePerks(ViewParamsComponent viewParams)
  {
    ExecutablePerks?.Invoke(viewParams);
  }
  #endregion
}