using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Perk AddMaxHealth
namespace BlackRainbow.PerkSystem
{
    [CreateAssetMenu(fileName = "CreateNewPerk", menuName = "PerkSO/Perk/CreateNewPerk", order = 1)]
    public class AddMaxHealthSO : AbstractPerkSO
    {
        public override void ActivatePerkPlayer(BasePersonView playerView)
        {
            base.ActivatePerkPlayer(playerView);

            for (int i = 0; i < _actions.Length; i++)
            {
                switch (_actions[i].TypeAction)
                {
                    case AbstractActionPerkSO.ActionType.Buff:
                        var newValue = _actions[i].ExecuteAction(playerView.ViewParams.MaxHealth);
                        playerView.ViewParams.ChangeMaxHealth(newValue);
                        break;
                    case AbstractActionPerkSO.ActionType.Debuff:
                        break;
                    case AbstractActionPerkSO.ActionType.AreaEffect:
                        break;
                }
            }

        }

        protected override void InternalAddLevel()
        {
            // TODO
        }
    }
}