using System;
using UnityEngine;


public class LevelEvents
{
    public static LevelEvents Current = new LevelEvents();

    public event Action OnLevelChanged;
    public void LevelChanged()
    {
        OnLevelChanged?.Invoke();
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
    public event Action OnGameLaunched;
    public void GameLaunched()
    {
        OnGameLaunched?.Invoke();
    }
    public event Action OnLevelStart;
    public void LevelStart()
    {
        OnLevelStart?.Invoke();
    }
    public event Action OnLevelRestart;
    public void LevelRestart()
    {
        OnLevelRestart?.Invoke();
    }
}