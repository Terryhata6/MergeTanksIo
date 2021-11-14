using UnityEngine;

[System.Serializable]
public class ViewParamsComponent
{
    public float Health;
    public float MaxHealth;
    public float MoveSpeed;
    public float Shield;

    public void ChangeMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
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