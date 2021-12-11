using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameEvents
{
    public static GameEvents Current = new GameEvents();

    // public event Action<Projectile> OnRemoveProjectile;

    public event Action<BaseProjectile> OnRemoveBaseProjectile;

    public void RemoveBaseProjectile(BaseProjectile baseProjectile)
    {
        OnRemoveBaseProjectile?.Invoke(baseProjectile);
    }

    public event Action<CollectablesParam> OnCollectablesParamSet;

    public void CollectablesParamSet(CollectablesParam cp)
    {
        OnCollectablesParamSet?.Invoke(cp);
    }



    // public void RemoveProjectile(Projectile projectile)
    // {
    //     OnRemoveProjectile?.Invoke(projectile);
    // 
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
    public event Action OnPlayerDead;
    public void PlayerDead()
    {
        OnPlayerDead?.Invoke();
    }

    public event Action<GameObject> OnAimAppeared;

    public void AimAppeared(GameObject aim)
    {
        OnAimAppeared?.Invoke(aim);
    }

    public event Action<CinemachineVirtualCamera> OnVirtualCamSet;

    public void VirtualCamSet(CinemachineVirtualCamera camera)
    {
        OnVirtualCamSet?.Invoke(camera);
    }


    public event Action<PersonType> OnPlayerTypeChoose;

    public void PlayerTypeChoose(PersonType type)
    {
        OnPlayerTypeChoose?.Invoke(type);
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

    #region Perks
    public event Action<List<AbstractPerk>> OnSetSelectPerks;
    public void SetSelectPerks(List<AbstractPerk> perks)
    {
        OnSetSelectPerks?.Invoke(perks);
    }

    public event Action<AbstractPerk> OnSelectPerk;
    public void SelectPerk(AbstractPerk perk)
    {
        OnSelectPerk?.Invoke(perk);
    }
    #endregion
}