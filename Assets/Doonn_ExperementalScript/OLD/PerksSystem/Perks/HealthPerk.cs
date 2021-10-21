using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerk : BasePerkSystem
{
    private float _health = 50f;
    private float _newHealth;

    public HealthPerk ()
    {
        _name = "AddHealth";
        _description = "Добавляет ХП +50";
        
    }

    public float Health (float currentHealth)
    {
        _newHealth = currentHealth + _health;
        return _newHealth;
    }

    public override void GetCalculate ()
    {

    }
}