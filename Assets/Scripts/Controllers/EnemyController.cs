using System.Collections.Generic;
using Polarith.AI.Move;
using UnityEngine;

public class EnemyController : BaseController, IObjectExecuter, IFixedExecute
{
    private List<EnemyView> _enemies;
    private Dictionary<EnemyState, IEnemyState> _states;
    private EnemyView _temp;
    private AIMComponents _aim;
    private GameObject _tempAim;
    private AIMComponents _tempAimComponents;

    public override void Initialize()
    {
        base.Initialize();
        _enemies = new List<EnemyView>();
        _states = new Dictionary<EnemyState, IEnemyState>();
        _states.Add(EnemyState.Attack, new EnemyAttackStateModel());
        _states.Add(EnemyState.Search, new EnemySearchStateModel());
        _states.Add(EnemyState.Collect, new EnemyCollectStateModel());
        _states.Add(EnemyState.Merge, new EnemyMergeStateModel());

        GameEvents.Current.OnAimAppeared += SetAim;
        GameEvents.Current.OnEnemyDead += RemoveObj;
    }

    public override void FixedExecute()
    {
        base.Execute();
        for (int i = 0; i < _enemies.Count; i++)
        {

            _states[_enemies[i].State].Execute(_enemies[i]);
            _enemies[i].Attack();
        }
    }

    private void EnemyInit(EnemyView enemy)
    {
        enemy.gameObject.layer = (int) Layers.Enemies;
        enemy.State = EnemyState.Search;
        if (_aim)
        {
            _tempAim = GameObject.Instantiate(_aim.gameObject, enemy.transform);
            _tempAim.SetActive(true);
            if (_tempAim.TryGetComponent(out _tempAimComponents))
            {
                enemy.Context = _tempAimComponents.Context;
                enemy.SetSeekers(_tempAimComponents.Seekers);
            }
            _tempAim.transform.localPosition = Vector3.zero;
            enemy.Context.SelfObject = enemy.gameObject;
        }
    }

    private void SetAim(AIMComponents aim)
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