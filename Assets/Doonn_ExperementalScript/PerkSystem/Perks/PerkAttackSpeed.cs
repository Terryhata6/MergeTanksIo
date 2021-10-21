using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AttackSpeed", menuName = "ScriptableObjects/AttackSpeed", order = 1)]
public class PerkAttackSpeed : AbstractPerk
{
    [SerializeField] private float _speed = 0.1f;
    
    public override void Activate (Shooter ownShoot)
    {
        float newSpeed = AttackSpeed (ownShoot.ShotInterval);

        ownShoot.SetShotInterval (newSpeed);

    }
    
    private float AttackSpeed (float speed)
    {
        if (speed <= 0.1) return speed;
        return speed -= _speed;
    }


}