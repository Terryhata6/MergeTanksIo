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

    public event Action OnLevelChanged;
    public void LevelChanged()
    {
        OnLevelChanged?.Invoke();
    }

    public event Action<Particles> OnParticlesAppear;
    public void ParticlesAppear(Particles ps)
    {
        OnParticlesAppear?.Invoke(ps);
    }
    public event Action<CollectableItem> OnItemCollected;
    public void ItemCollected(CollectableItem coin)
    {
        OnItemCollected?.Invoke(coin);
    }

    //Events used from UI
    public event Action OnLevelComplete;
    public void LevelComplete()
    {
        OnLevelComplete?.Invoke();
    }

    public event Action OnLevelFailed;
    public void LevelFailed()
    {
        OnLevelFailed?.Invoke();
    }

    public event Action OnLevelNext;
    public void LevelNext()
    {
        OnLevelNext?.Invoke();
    }

    public event Action OnLevelRestart;
    public void LevelRestart()
    {
        OnLevelRestart?.Invoke();
    }
}