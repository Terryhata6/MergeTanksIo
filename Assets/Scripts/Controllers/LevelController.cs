
using System.Collections.Generic;
using UnityEngine;

public class LevelController : BaseController
{
    [SerializeField] private List<GameObject> _levels = new List<GameObject>();
    private Queue<Transform> _spawns = new Queue<Transform>();
    private GameObject _currentLevel;


    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(KeyCode.N))
        {
            var n = _spawns.Dequeue();
            Debug.Log(n.position);
            _spawns.Enqueue(n);
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("LevelController Start");
        LevelEvents.Current.OnLevelStarted += ChangeLevel;
        LevelEvents.Current.OnLevelEnded += DisableLevel;

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
    public void AddSpawnPoint(Transform spawn)
    {
        _spawns.Enqueue(spawn);
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
