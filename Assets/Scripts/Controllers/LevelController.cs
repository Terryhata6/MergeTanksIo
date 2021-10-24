using System.Collections.Generic;
using UnityEngine;

public class LevelController : BaseController
{
    [SerializeField] private List<GameObject> _levels = new List<GameObject>();
    private LevelConfig _currentLevel;
    private GameObject _levelPrefab;
    private int j;
    

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("LevelController Start");
        LevelEvents.Current.OnLevelNext += ChangeLevel;
        ChangeLevel();

    }

    private void DisableLevel()
    {
        if (_levelPrefab)
        {
            GameObject.Destroy(_levelPrefab);
            _levelPrefab = null;
        }
    }

    private void ChangeLevel()
    {

        Debug.Log("lVL cHANGE");
        DisableLevel();
        if (_levelPrefab == null && _levels.Count > 0)
        {
            _levelPrefab = Object.Instantiate(this?.GetRandomLevel());
            _levelPrefab.SetActive(true);
            if (_levelPrefab.TryGetComponent(out _currentLevel)) 
            {
                LevelEvents.Current.ParticlesAppear(_currentLevel.Particles);
            };
            LevelEvents.Current.LevelChanged();
        }
    }

    private GameObject GetRandomLevel()
    {
        return _levels[GetRandomLevelIndex()];
    }

    private int GetRandomLevelIndex()
    {
        return Random.Range(0, _levels.Count);
    }

    public void SetLevels(List<GameObject> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            Debug.Log($"SetLevel{i + 1}");
            _levels.Add(levels[i]);
        }
    }
}

