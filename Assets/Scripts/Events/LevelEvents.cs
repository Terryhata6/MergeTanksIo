using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents
{
    public static LevelEvents Current = new LevelEvents();

    public event Action OnLevelEnded;
    public void LevelEnded()
    {
        OnLevelEnded?.Invoke();

    }
    public event Action OnLevelStarted;
    public void LevelStarted()
    {
        OnLevelStarted?.Invoke();
    }

    //public event Action<List<GameObject>> OnGetLevels;
    //public void GetLevels (List<GameObject> levels)
    //{
    //    OnGetLevels?.Invoke(levels);
    //}

    //public event Action<Transform> OnSpawnPointAppear;

    //public void SpawnPointAppear(Transform position)
    //{
    //    OnSpawnPointAppear?.Invoke(position);
    //}
    
    //public event Action<ICollectableItem> OnCollectableItemAppear;
    //public void CollectabeItemAppear(ICollectableItem item)
    //{
    //    OnCollectableItemAppear?.Invoke(item);
    //}
    
    //public event Action<List<Transform>> OnSpawnPointsSet;
    //public void TouchStationary(List<Transform> spawns)
    //{
    //    OnSpawnPointsSet?.Invoke(spawns);
    //}

}