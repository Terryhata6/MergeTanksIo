using System;
using UnityEngine;

[System.Serializable]
public class ViewParamsComponent
{
    public float Health;
    public float MaxHealth;
    public float MoveSpeed;

    //<<Alt_Enter
    public float RotationSpeed;
    //>>End
    public float Shield;

    public void ChangeMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }
    //<<Alt_Enter
    public void ChangeRotationSpeed(float rotation)
    {
        RotationSpeed = rotation;
    }
    //>>End
    public void ChangeHealth(float health)
    {
        Health = health;
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        if (Health <= 0)
        {
            Debug.Log(Health);
            Health = 0;
            IsDead();
        }

    }

    public void ChangeMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    public void ChangeShield(float shield)
    {
        Shield = shield;
    }

    #region Interaction
    public bool IsDead()
    {
        return true;
    }
    #endregion
}