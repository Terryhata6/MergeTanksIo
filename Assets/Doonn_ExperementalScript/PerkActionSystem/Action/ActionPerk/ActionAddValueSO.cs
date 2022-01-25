using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkSystem
{
    [CreateAssetMenu(fileName = "ActionAddValueSO", menuName = "PerkSO/Action/ActionAddValueSO", order = 1)]

    public class ActionAddValueSO : AbstractActionPerkSO
    {
        [SerializeField] private float _value;
        public float Value => _value;

        public override float ExecuteAction(float ownValue)
        {
            base.ExecuteAction(ownValue);
            return ownValue + _value;
        }
    }
}