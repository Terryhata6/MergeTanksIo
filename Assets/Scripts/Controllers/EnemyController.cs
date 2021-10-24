using UnityEngine;
using System.Collections.Generic;

public class EnemyController : BaseController, IObjectExecuter
{
    private List<EnemyView> _enemies;
    private Dictionary<EnemyState, IEnemyState> _states;
    private EnemyView _temp;

    public override void Initialize()
    {
        base.Initialize();
        _enemies = new List<EnemyView>();
        _states = new Dictionary<EnemyState, IEnemyState>();
    }

    public override void Execute()
    {
        base.Execute();
        for (int i = 0; i < _enemies.Count; i ++ )
        {
           _states[_enemies[i].State].Execute(_enemies[i]);
        }
    }

    public void AddObj(GameObject obj)
    {
        obj.AddComponent<EnemyView>();
        _enemies.Add(obj.GetComponent<EnemyView>());
    }

    public void RemoveObj(EnemyView obj)
    {
        _enemies.Remove(obj);
    }
}