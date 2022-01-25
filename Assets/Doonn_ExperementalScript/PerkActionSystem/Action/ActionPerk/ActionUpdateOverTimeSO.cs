using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkSystem
{
    [CreateAssetMenu(fileName = "ActionUpdateOverTimeSO", menuName = "PerkSO/Action/ActionUpdateOverTimeSO", order = 1)]
    public class ActionUpdateOverTimeSO : AbstractActionPerkSO
    {
        [SerializeField] private float _value = 1.0f;
        [SerializeField] private float _delay = 1.0f;
        private float _tempDelay = 0f;

        public override float ExecuteAction()
        {
            _tempDelay += Time.deltaTime;
            if (_tempDelay >= _delay)
            {
                Debug.Log("ActionUpdateOverTimeSO");
                _tempDelay = 0f;
                return 1;
            }
            return 0;
        }
    }
}