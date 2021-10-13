using System;
using UnityEngine.Events;


public class LevelEvents
{
    public static LevelEvents Current = new LevelEvents();

    public event UnityAction OnLevelEnded;
    public void LevelEnded()
    {
        OnLevelEnded?.Invoke();

    }
    public event UnityAction OnLevelStarted;
    public void LevelStarted()
    {
        OnLevelStarted?.Invoke();
    }

    public event UnityAction OnLevelChanged;
    public void LevelChanged()
    {
        OnLevelChanged?.Invoke();
    }

    public event Action<CollectableItem> OnItemCollected;
    public void ItemCollected(CollectableItem coin)
    {
        OnItemCollected?.Invoke(coin);
    }

    public event Action<Particles> OnParticlesAppear;

    public void ParticlesAppear(Particles particles)
    {
        OnParticlesAppear?.Invoke(particles);
    }

    public event UnityAction<PersonType> OnPlayerSelected;

    public void PlayerSelected()
    {
        OnPlayerSelected?.Invoke(PersonType.PlayerDino);
    }
    
    
    
    

}