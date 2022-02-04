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

    private bool _isDead = false;
 //   public bool IsDead => _isDead;

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
            Health = 0;
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
        if (Health <= 0)
        {
       //     Debug.Log(Health);
            Health = 0;
            return true;
        }
        return false;
    }
    #endregion


    #region LevelUp
    [SerializeField] private int _level = 1;
    [SerializeField] private int _experience = 0;
    [SerializeField] private int _needExperianceToLevelUp = 100;

    public void AddExperiance(int exp, GameObject ownGameObject)
    {
        _experience += exp;
        if (_experience >= _needExperianceToLevelUp)
        {
            _level++;
            GameEvents.Current.LevelUp(ownGameObject);
            _experience -= _needExperianceToLevelUp;
        }
    }
    #endregion
}