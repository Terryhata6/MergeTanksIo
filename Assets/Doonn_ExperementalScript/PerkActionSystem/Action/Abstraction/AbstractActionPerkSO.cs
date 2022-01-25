using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkSystem
{
    public abstract class AbstractActionPerkSO : ScriptableObject
    {
        public enum ActionType
        {
            Buff,
            Debuff,
            AreaEffect,
            BuffUpdateOverTime
        }

        [SerializeField] private ActionType _actionType;
        public ActionType TypeAction => _actionType;
        public virtual float ExecuteAction()
        {
            return 0;
        }
        public virtual float ExecuteAction(float ownValue)
        {
            return ownValue;
        }
        public virtual int ExecuteAction(int ownValue)
        {
            return ownValue;
        }
    }
}