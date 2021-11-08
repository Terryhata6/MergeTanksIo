using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "ScriptableObjects/AttackSpeed", order = 1)]
public class AttackSpeedPerk : AbstractPerk
{
    [SerializeField] private float _speed = 10f; //<< Percentag
    private float _tempPrecentage;
    private Shooter _ownShooter;
    private AttackSpeedPerk()
    {
        _typePerk = PerkType.Offence;
        _speed = 10f;
        _level = 1;
        _maxLevel = 5;
    }

    public override void Activate(Shooter ownShoot)
    {
        _ownShooter = ownShoot;
        float newSpeed = AttackSpeed(ownShoot.ShootInterval);
        ownShoot.SetShootInterval(newSpeed);

    }


    public override void Deactivate(Shooter ownShoot)
    {
        float newSpeed = ownShoot.ShootInterval + _tempPrecentage;

        ownShoot.SetShootInterval(newSpeed);

    }


    private float AttackSpeed(float speed)
    {
        _tempPrecentage = (speed / 100) * _speed;

        return speed -= _tempPrecentage;
    }

    public override void AddLevel()
    {
        if (_level >= _maxLevel)
        {
            Debug.Log("Max Level");
        }
        else
        {
            _level++;
            float newSpeed = AttackSpeed(_ownShooter.ShootInterval);
            _ownShooter.SetShootInterval(newSpeed);
        }
    }
    public override void RemoveLevel()
    {
        if (_level <= 0)
        {
            return;
        }
        else
        {
            _level--;
            float newSpeed = _ownShooter.ShootInterval + _tempPrecentage;
            _ownShooter.SetShootInterval(newSpeed);
        }
    }
}