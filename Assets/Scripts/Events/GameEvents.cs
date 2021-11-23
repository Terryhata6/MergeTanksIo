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
    public event Action<CollectablesParam> OnCollectablesParamSet;
    public void CollectablesParamSet(CollectablesParam cp)
    {
        OnCollectablesParamSet?.Invoke(cp);
    }
    public event Action<CollectableItem> OnItemCollected;
    public void ItemCollected(CollectableItem coin)
    {
        OnItemCollected?.Invoke(coin);
    }

    public event Action OnEnemyRespawn;

    public void RespawnEnemy()
    {
        OnEnemyRespawn?.Invoke();
    }
    public event Action<EnemyView> OnEnemyDead;

    public void EnemyDead(EnemyView enemy)
    {
        OnEnemyDead?.Invoke(enemy);
    }

    public event Action<GameObject> OnAimAppeared;

    public void AimAppeared(GameObject aim)
    {
        OnAimAppeared?.Invoke(aim);
    }

    public event Action OnEnvironmentUpdated;

    public void EnvironmentUpdated()
    {
        OnEnvironmentUpdated?.Invoke();
    }

    public event Action<CollectableItem> OnCollectableDisable;

    public void CollectableDisable(CollectableItem col)
    {
        OnCollectableDisable?.Invoke(col);
    }
}