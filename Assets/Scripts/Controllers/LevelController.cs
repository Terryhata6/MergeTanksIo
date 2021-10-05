
using System.Collections.Generic;
using UnityEngine;

public class LevelController : BaseController
{
    [SerializeField] private List<GameObject> _levels = new List<GameObject>();
    private Queue<Transform> _spawns = new Queue<Transform>();
    private List<Transform> _temp = new List<Transform>();
    private GameObject _currentLevel;
    private int j;
    private Transform _spawn;

    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(GetSpawnPoint());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            LevelEvents.Current.LevelStarted();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            LevelEvents.Current.LevelEnded();
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("LevelController Start");
        LevelEvents.Current.OnLevelStarted += ChangeLevel;
        LevelEvents.Current.OnLevelEnded += DisableLevel;
        LevelEvents.Current.OnLevelStarted += ShuffleSpawns;

    }

    private void DisableLevel()
    {
        Debug.Log("LevelEnd");
        if(_currentLevel != null)   Object.Destroy(_currentLevel);   
    }

    private void ChangeLevel()
    {
        Debug.Log("LevelStart");
        if (_currentLevel == null && _levels.Count >0)
        {
            _currentLevel = Object.Instantiate(this?.GetRandomLevel());
            _currentLevel.SetActive(true);
        }
    }

    private GameObject GetRandomLevel()
    {
        return _levels[GetRandomLevelIndex()];
    }

    private int GetRandomLevelIndex()
    {
        return Random.Range(0,_levels.Count);
    }

    private void ShuffleSpawns()
    {
        Debug.Log("shuffled");
        for (int i = _temp.Count - 1; i>=1; i--)
        {
            j = Random.Range(0, i + 1);
            _spawns.Enqueue(_temp[j]);
            _temp.RemoveAt(j);
        }
    }

    public Transform GetSpawnPoint()
    {
        _spawn = _spawns.Dequeue();
        _spawns.Enqueue(_spawn);
        return _spawn;
    }

    public void AddSpawnPoint(Transform spawn)
    {
        _temp.Add(spawn);
    }

    public void SetLevels(List<GameObject> levels)
    {
        for (int i = 0; i<levels.Count; i++)
        {
            Debug.Log($"SetLevel{i + 1}");
            _levels.Add(levels[i]);
        }
    }
}
