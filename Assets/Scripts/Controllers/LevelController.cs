using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class LevelController : BaseController, IFixedExecute
{
    [SerializeField] private List<GameObject> _levels = new List<GameObject>();
    private LevelConfig _currentLevel;
    private GameObject _levelPrefab;
    private AIMSteeringPerceiver _environment;
    private int j;
    

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("LevelController Start");
        LevelEvents.Current.OnLevelNext += ChangeLevel;
        LevelEvents.Current.OnGameLaunched += ChangeLevel;
        GameEvents.Current.OnEnvironmentUpdated += UpdateEnvironment;

    }

    public override void FixedExecute()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            UpdateEnvironment();
        }
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
                GameEvents.Current.CollectablesParamSet(_currentLevel.CollectableParams);
                GameEvents.Current.AimAppeared(_currentLevel.Aim);
                _environment = _currentLevel.Environment;
            };
            LevelEvents.Current.LevelChanged();
        }
    }

    private void UpdateEnvironment()
    {
        if (_environment)
        {
            for (int i = 0; i < _environment.Environments.Count; i++)
            {
                _environment.Environments[i].UpdateLayerGameObjects();
            }
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

