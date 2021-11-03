using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AttackSpeed", menuName = "ScriptableObjects/AttackSpeed", order = 1)]
public class AttackSpeedPerk : AbstractPerk
{
    [SerializeField] private float _speed = 10f; //<< Percentag
    private float _tempPrecentage;

    private AttackSpeedPerk ()
    {
        _typePerk = PerkType.Offence;
        _speed = 10f;
    }

    public override void Activate (Shooter ownShoot)
    {
        float newSpeed = AttackSpeed (ownShoot.ShootInterval);
        ownShoot.SetShootInterval (newSpeed);

    }


    public override void Deactivate (Shooter ownShoot)
    {
        float newSpeed = ownShoot.ShootInterval + _tempPrecentage;

        ownShoot.SetShootInterval (newSpeed);

    }


    private float AttackSpeed (float speed)
    {
        _tempPrecentage = (speed / 100) * _speed;

        return speed -= _tempPrecentage;
    }


}