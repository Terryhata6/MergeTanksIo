using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PerkSystem
{
    [SerializeField] private List<AbstractPerk> _perkList = new List<AbstractPerk>();
    public List<AbstractPerk> PerkList => _perkList;

    [SerializeField] private List<AbstractPerk> _perkListOnEnable = new List<AbstractPerk>();
    public List<AbstractPerk> PerkListOnEnable => _perkListOnEnable;

    private PlayerView _playerView;
    private Shooter _shooter;

    public PerkSystem(PlayerView playerView, Shooter shooter)
    {
        _playerView = playerView;
        _shooter = shooter;
    }

    public void AddPerk(AbstractPerk perk)
    {
        foreach (var item in _perkListOnEnable)
        {
            if (item.GetType() == perk.GetType()) return;
        }

        if (perk.OnEnable)
        {
            _perkListOnEnable.Add(perk);
        }
        else
        {
            _perkList.Add(perk);
        }

        if (perk.FixedExecute)
        {
            _playerView.ExecutablePerks += perk.Activate;
        }

        switch (perk.TypePerk)
        {
            case PerkType.Defence:
                perk.Activate(_playerView);
                break;
            case PerkType.Offence:
                perk.Activate(_shooter);
                break;
        }
    }

    public void RemovePerk(AbstractPerk perk)
    {
        _perkList.Remove(perk);

        if (perk.FixedExecute)
        {
            _playerView.ExecutablePerks -= perk.Activate;
        }

        switch (perk.TypePerk)
        {
            case PerkType.Defence:
                perk.Deactivate(_playerView);
                break;
            case PerkType.Offence:
                perk.Deactivate(_shooter);
                break;
        }
    }



    // private void OnActivatePerkAll (PlayerView player, Shooter shooter)
    // {
    //     foreach (var perk in _perkList)
    //     {
    //         switch (perk.TypePerk)
    //         {
    //             case PerkType.Defence:
    //                 perk.Activate (player);
    //                 break;
    //             case PerkType.Offence:
    //                 perk.Activate (shooter);
    //                 break;
    //         }
    //     }
    // }

    // private void OnDeactivatePerkAll (PlayerView player, Shooter shooter)
    // {
    //     foreach (var perk in _perkList)
    //     {
    //         switch (perk.TypePerk)
    //         {
    //             case PerkType.Defence:
    //                 perk.Deactivate (player);
    //                 break;
    //             case PerkType.Offence:
    //                 perk.Deactivate (shooter);
    //                 break;
    //         }
    //     }
    // }
}