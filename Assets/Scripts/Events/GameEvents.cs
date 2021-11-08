using System;
using UnityEngine;

public class GameEvents
{
    public static GameEvents Current = new GameEvents();

    public event Action<Projectile> OnRemoveProjectile;

    public void RemoveProjectile(Projectile projectile)
    {
        OnRemoveProjectile?.Invoke(projectile);
    }
}