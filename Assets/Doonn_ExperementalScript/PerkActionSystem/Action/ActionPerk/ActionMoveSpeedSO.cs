using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackRainbow.PerkSystem
{
    [CreateAssetMenu(fileName = "ActionMoveSpeedSO", menuName = "PerkSO/Action/ActionMoveSpeedSO", order = 1)]
    public class ActionMoveSpeedSO : AbstractActionPerkSO
    {
        [SerializeField] private float _speed = 10f; //<< Percentag

        private float _tempPrecentage;

        public override float ExecuteAction(float _ownValue)
        {
            float newSpeed = AddMoveSpeed(_ownValue);
            return newSpeed;
        }

        private float AddMoveSpeed(float speed)
        {
            _tempPrecentage = (speed / 100) * _speed;

            return speed += _tempPrecentage;
        }
    }
}