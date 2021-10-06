using System;


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

    public event Action<CollectableItem> OnItemCollected;
    public void ItemCollected(CollectableItem coin)
    {
        OnItemCollected?.Invoke(coin);
    }

}