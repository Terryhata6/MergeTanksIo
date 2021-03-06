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

    public event Action<BasePersonView> OnPersonDead;

    public void PersonDead(BasePersonView view)
    {
        OnPersonDead?.Invoke(view);
    }
    
    public event Action<CollectableSpray> OnSprayAvaible;

    public void SprayAvaible(CollectableSpray spray)
    {
        OnSprayAvaible?.Invoke(spray);
    }

    public event Action<AIMComponents> OnAimAppeared;

    public void AimAppeared(AIMComponents aim)
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
    public event Action<GameObject> OnMergeObj;
    public void MergeObj(GameObject Obj)
    {
        OnMergeObj?.Invoke(Obj);
    }
    
    #endregion
}