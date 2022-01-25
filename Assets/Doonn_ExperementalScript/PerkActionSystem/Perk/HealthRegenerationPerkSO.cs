using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkSystem
{
    [CreateAssetMenu(fileName = "HealthRegenerationPerkSO", menuName = "PerkSO/Perk/HealthRegenerationPerkSO", order = 1)]
    public class HealthRegenerationPerkSO : AbstractPerkSO
    {
        public override void ActivatePerkPlayer(BasePersonView playerView)
        {
            base.ActivatePerkPlayer(playerView);
        }

        public override void UpdateOverTime(BasePersonView playerView)
        {
            base.UpdateOverTime(playerView);
            AbstractActionPerkSO action = null;

            for (int i = 0; i < _actions.Length; i++)
            {
                switch (_actions[i].TypeAction)
                {
                    case AbstractActionPerkSO.ActionType.Buff:
                        break;
                    case AbstractActionPerkSO.ActionType.Debuff:
                        break;
                    case AbstractActionPerkSO.ActionType.AreaEffect:
                        break;
                    case AbstractActionPerkSO.ActionType.BuffUpdateOverTime:
                        action = _actions[i];
                        break;
                }
            }
            Execute(action, playerView);
        }

        private void Execute(AbstractActionPerkSO action, BasePersonView playerView)
        {
            if (action.ExecuteAction() >= 1)
            {
                for (int i = 0; i < _actions.Length; i++)
                {
                    switch (_actions[i].TypeAction)
                    {
                        case AbstractActionPerkSO.ActionType.Buff:
                            var newHealth = _actions[i].ExecuteAction(playerView.ViewParams.Health);
                            Debug.Log(newHealth + "SDASSSSSS");
                            playerView.ViewParams.ChangeHealth(newHealth);
                            break;
                        case AbstractActionPerkSO.ActionType.Debuff:
                            break;
                        case AbstractActionPerkSO.ActionType.AreaEffect:
                            break;
                        case AbstractActionPerkSO.ActionType.BuffUpdateOverTime:
                            break;
                    }
                }
            }
        }

        protected override void InternalAddLevel()
        {
            throw new System.NotImplementedException();
        }

    }
}