using System;
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
  [SerializeField] List<AbstractPerk> _ownProjectileModList = new List<AbstractPerk>();
  public List<AbstractPerk> OwnProjectileModList => _ownProjectileModList;

  [SerializeField] private List<AbstractPerk> _frozenPerkList = new List<AbstractPerk>();

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
    switch (perk.PerkData.ModBelongs)
    {
      case PerkType.ViewParamsMod:
        DefineModViewParams(perk);
        break;
      case PerkType.WeaponMod:
        DefineModWeapon(perk);
        break;
      case PerkType.ProjectileMod:
        DefineModProjectile(perk);
        break;
    }
  }

  private void DefineModViewParams(AbstractPerk perk)
  {
    switch (perk.PerkData.TypePerk)
    {
      case PerkType.Defence:
        if (PlayerMatchingPerk(perk))
        {
          AddPlayerPerk(perk);
        }
        else
        {
          ChangePlayerPerkLevel(perk);
        }
        break;
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      case PerkType.Offence:
        if (PlayerMatchingPerk(perk))
        {
          AddPlayerPerk(perk);
        }
        else
        {
          ChangePlayerPerkLevel(perk);
        }
        break;
    }
    CheckShooterPerkListPriority();
  }

  private void DefineModWeapon(AbstractPerk perk)
  {
    switch (perk.PerkData.TypePerk)
    {
      case PerkType.Defence:
        if (ShooterMatchingPerk(perk))
        {
          AddShooterPerk(perk);
        }
        else
        {
          ChangeShootePerkLevel(perk);
        }
        break;
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      case PerkType.Offence:
        if (ShooterMatchingPerk(perk))
        {
          AddShooterPerk(perk);
        }
        else
        {
          ChangeShootePerkLevel(perk);
        }
        break;
    }
    CheckShooterPerkListPriority();
  }

  private void DefineModProjectile(AbstractPerk perk)
  {
    switch (perk.PerkData.TypePerk)
    {
      // case PerkType.Defence:
      //   if (ShooterMatchingPerk(perk))
      //   {
      //     AddShooterPerk(perk);
      //   }
      //   else
      //   {
      //     ChangeShootePerkLevel(perk);
      //   }
      //   break;
      //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      case PerkType.Offence:
        if (ProjectileMatchingPerk(perk))
        {
          AddProjectilePerk(perk);
        }
        else
        {
          ChangeProjectilePerkLevel(perk);
        }
        break;
    }
  }

  #region Perk PlayerParams
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

  private void AddPlayerPerk(AbstractPerk perk)
  {
    _ownPlayerPerkList.Add(perk);
    perk.Activate(_ownViewParams);
    if (perk.IsActiveBuff)
    {
      ExecutablePerks += perk.ActivateBuff;
    }
  }

  private void ChangePlayerPerkLevel(AbstractPerk perk)
  {
    for (int i = 0; i < _ownPlayerPerkList.Count; i++)
    {
      if (_ownPlayerPerkList[i].GetType().Equals(perk.GetType()))
      {
        _ownPlayerPerkList[i].AddLevel();
      }
    }
  }

  public void RemovePlayerPerk(AbstractPerk perk)
  {
    _ownPlayerPerkList.Remove(perk);
    perk.Deactivate(_ownViewParams);

    if (perk.IsActiveBuff)
    {
      ExecutablePerks -= perk.ActivateBuff;
    }
  }
  #endregion

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

  private void AddShooterPerk(AbstractPerk perk)
  {
    _ownShooterPerkList.Add(perk);

    #region Если находим Конфликт Перок То Конфликтную перку замараживаем
    if (perk.ConflictPerk != null)
    {
      _frozenPerkList.Add(perk.ConflictPerk);
      for (int i = 0; i < _ownShooterPerkList.Count; i++)
      {
        if (_ownShooterPerkList[i].GetType() == perk.ConflictPerk.GetType())
        {
          _ownShooterPerkList.RemoveAt(i);
        }
      }
    }
    #endregion

    perk.Activate(_ownShooteer);

    if (perk.IsActiveBuff)
    {
      ExecutablePerks += perk.ActivateBuff;
    }
  }

  private void ChangeShootePerkLevel(AbstractPerk perk)
  {
    for (int i = 0; i < _ownShooterPerkList.Count; i++)
    {
      if (_ownShooterPerkList[i].GetType().Equals(perk.GetType()))
      {
        _ownShooterPerkList[i].AddLevel();
      }
    }
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

    if (perk.IsActiveBuff)
    {
      ExecutablePerks -= perk.ActivateBuff;
    }
  }

  #region Projectile Modification
  private void AddProjectilePerk(AbstractPerk baseProjectilePerk)
  {
    _ownProjectileModList.Add(baseProjectilePerk);
  }

  private void ChangeProjectilePerkLevel(AbstractPerk baseProjectilePerk)
  {
    for (int i = 0; i < _ownProjectileModList.Count; i++)
    {
      if (_ownProjectileModList[i].GetType().Equals(baseProjectilePerk.GetType()))
      {
        _ownProjectileModList[i].AddLevel();
      }
    }
  }

  private bool ProjectileMatchingPerk(AbstractPerk baseProjectilePerk)
  {
    for (int i = 0; i < _ownProjectileModList.Count; i++)
    {
      if (_ownProjectileModList[i].GetType().Equals(baseProjectilePerk.GetType()))
      {
        return false;
      }
    }
    return true;
  }
  #endregion


  #region Events Perk FixedExecute is True
  public event Action<ViewParamsComponent> ExecutablePerks;
  public void ExecutePerks(ViewParamsComponent viewParams)
  {
    ExecutablePerks?.Invoke(viewParams);
  }
  #endregion
}