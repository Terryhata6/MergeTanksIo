using UnityEngine;
using System.Collections.Generic;
using Polarith.AI.Move;

public class EnemyController : BaseController, IObjectExecuter, IFixedExecute
{
    private List<EnemyView> _enemies;
    private Dictionary<EnemyState, IEnemyState> _states;
    private EnemyView _temp;
    private GameObject _aim;
    private GameObject _tempAim;
    private AIMContext _tempContext;

    public override void Initialize()
    {
        base.Initialize();
        _enemies = new List<EnemyView>();
        _states = new Dictionary<EnemyState, IEnemyState>();
        _states.Add(EnemyState.Attack, new EnemyAttackStateModel());
        _states.Add(EnemyState.Search, new EnemySearchStateModel());
        _states.Add(EnemyState.Collect, new EnemyCollectStateModel());
        
        GameEvents.Current.OnAimAppeared += SetAim;
        GameEvents.Current.OnEnemyDead += RemoveObj;
    }

    public override void FixedExecute()
    {
        base.Execute();
        Debug.Log("enemy");
        for (int i = 0; i < _enemies.Count; i ++ )
        {
            
            _states[_enemies[i].State].Execute(_enemies[i]);
            Debug.Log("SS: " + i);
        }
    }

    private void EnemyInit(EnemyView enemy)
    {
        enemy.gameObject.layer = (int) Layers.Enemies;
        enemy.State = EnemyState.Search;
        if (_aim)
        {
            _tempAim = GameObject.Instantiate(_aim, enemy.transform);
            _tempAim.SetActive(true);
            if (_tempAim.TryGetComponent(out _tempContext))
            {
                enemy.Context = _tempContext;
            }
            _tempAim.transform.localPosition = Vector3.zero;
            enemy.Context.SelfObject = enemy.gameObject;
        }
    }

    private void SetAim(GameObject aim)
    {
        _aim = aim;
    }

    public void AddObj(GameObject obj)
    {
        if (obj.TryGetComponent(out _temp))
        {
            _enemies.Add(_temp);
            EnemyInit(_temp);
            GameEvents.Current.EnvironmentUpdated();
        }
    }

    public void RemoveObj(EnemyView obj)
    {
        _enemies.Remove(obj);
        GameEvents.Current.RespawnEnemy();
    }
}