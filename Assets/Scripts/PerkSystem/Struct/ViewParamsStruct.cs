using UnityEngine;

[System.Serializable]
public struct ViewParamsStruct
{
    public float Health;
    public float MaxHealth;
    public float MoveSpeed;
    public float Shield;

    public ViewParamsStruct(ViewParamsStruct  viewParams)
    {
        Health = viewParams.Health;
        MaxHealth = viewParams.MaxHealth;
        MoveSpeed = viewParams.MoveSpeed;
        Shield = viewParams.Shield;
    }
    

    public void ChangeMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
        RetrunThis();
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

    private ViewParamsStruct RetrunThis()
    {
        return this;
    }
}