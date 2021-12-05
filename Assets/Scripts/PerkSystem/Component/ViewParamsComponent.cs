using UnityEngine;

[System.Serializable]
public class ViewParamsComponent
{
    public float Health;
    public float MaxHealth;
    public float MoveSpeed;
    public float RotationSpeed;
    public float Shield;

    public void ChangeMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }
    public void ChangeRotationSpeed(float rotation)
    {
        RotationSpeed = rotation;
    }

    public void ChangeHealth(float health)
    {
        Health = health;
    }

    public void ChangeMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    public void ChangeShield(float shield)
    {
        Shield = shield;
    }
}