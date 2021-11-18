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
  private Shooter _ownShooteer;

  public PerkManager(ViewParamsComponent ownViewParams)
  {
    _ownViewParams = ownViewParams;
  }

  public PerkManager(ViewParamsComponent ownViewParams, Shooter ownShooter)
  {
    _ownViewParams = ownViewParams;
    _ownShooteer = ownShooter;
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
          for (int i = 0; i < _ownPlayerPerkList.Count; i++)
          {
            if (_ownPlayerPerkList[i].GetType().Equals(perk.GetType()))
            {
              _ownPlayerPerkList[i].AddLevel();
            }
          }
        }
        break;
      case PerkType.Offence:
        if (ShooterMatchingPerk(perk))
        {
          _ownShooterPerkList.Add(perk);
          perk.Activate(_ownShooteer);
          if (perk.FixedExecute)
          {
            ExecutablePerks += perk.UpdateFixedExecute;
          }
        }
        else
        {
          for (int i = 0; i < _ownShooterPerkList.Count; i++)
          {
            if (_ownShooterPerkList[i].GetType().Equals(perk.GetType()))
            {
              _ownShooterPerkList[i].AddLevel();
            }
          }
        }
        break;
    }
    CheckShooterPerkListPriority();
  }

  private bool PlayerMatchingPerk(AbstractPerk perk)
  {
    for (int i = 0; i < _ownPlayerPerkList.Count; i++)
    {
      if (_ownPlayerPerkList[i].GetType().Equals(perk.GetType()))
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
    for (int i = 0; i < _ownShooterPerkList.Count; i++)
    {
      if (_ownShooterPerkList[i].GetType().Equals(perk.GetType()))
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
    perk.Deactivate(_ownShooteer);

    if (perk.FixedExecute)
    {
      ExecutablePerks -= perk.UpdateFixedExecute;
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