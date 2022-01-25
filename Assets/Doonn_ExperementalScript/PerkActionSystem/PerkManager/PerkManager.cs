using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkManager
{
    using BlackRainbow.PerkSystem;
    [System.Serializable]
    public class PerkManager
    {
        [SerializeField] private List<AbstractPerkSO> _playerPerks = new List<AbstractPerkSO>();

        private PlayerView _playerView;

        public PerkManager(PlayerView view)
        {
            _playerView = view;
        }

        public void AddPerk(AbstractPerkSO perk)
        {
            switch (perk.PerkType)
            {
                case AbstractPerkSO.TypePerk.PlayerModification:
                    AddPlayerPerk(perk);
                    break;
                case AbstractPerkSO.TypePerk.WeaponModification:
                    break;
                case AbstractPerkSO.TypePerk.ProjectileModification:
                    break;
            }
        }

        private void AddPlayerPerk(AbstractPerkSO perk)
        {
            for (int i = 0; i < _playerPerks.Count; i++)
            {
                if (_playerPerks[i].GetType() == perk.GetType())
                {
                    _playerPerks[i].AddLevel();
                }
                else
                {
                    _playerPerks.Add(perk);
                    var actionTypes = perk.GetActions();
                    for (int t = 0; t < actionTypes.Length; t++)
                    {
                        if (actionTypes[t].TypeAction == AbstractActionPerkSO.ActionType.BuffUpdateOverTime)
                        {

                            UpdateOverTimePerk += perk.UpdateOverTime;
                        }
                    }
                    perk.ActivatePerkPlayer(_playerView);
                }
            }
        }

        #region Events Perk FixedExecute is True
        public event Action<BasePersonView> UpdateOverTimePerk;
        public void NewExecutePerks(BasePersonView viewParams)
        {
            UpdateOverTimePerk?.Invoke(viewParams);
        }
        #endregion
    }
}