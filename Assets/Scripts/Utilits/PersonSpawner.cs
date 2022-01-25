
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _temp;
    private Queue<Transform> _spawns;
    private Dictionary<PersonType, PersonConf> _personConfs;
    private GameObject _playerDino;
    private GameObject _playerTank;
    private GameObject _enemyDino;
    private GameObject _enemyTank;
    private GameObject _obj;
    private Transform _spawn;
    private int j;
    private List<float> _time;
    private PersonType _playerType;
    private List<PersonType> _enemyTypes;
    private void Awake()
    {
        _playerDino = Resources.Load<GameObject>("PlayerDino");
        _playerTank = Resources.Load<GameObject>("PlayerTank");
        _enemyDino = Resources.Load<GameObject>("EnemyDino");
        _enemyTank = Resources.Load<GameObject>("EnemyTank");
        
        _spawns = new Queue<Transform>();
        _time = new List<float>();
        _personConfs = new Dictionary<PersonType, PersonConf>();
        _enemyTypes = new List<PersonType>();
        _playerType = PersonType.PlayerTank;
        
        _personConfs.Add(PersonType.EnemyDino,
            new PersonConf(MainController.Current.GetController<EnemyController>(), _enemyDino));
        _personConfs.Add(PersonType.EnemyTank,
            new PersonConf(MainController.Current.GetController<EnemyController>(), _enemyTank));
        _personConfs.Add(PersonType.PlayerDino,
            new PersonConf(MainController.Current.GetController<PlayerController>(), _playerDino));
        _personConfs.Add(PersonType.PlayerTank,
            new PersonConf(MainController.Current.GetController<PlayerController>(), _playerTank));

        _enemyTypes.Add(PersonType.EnemyDino);
        _enemyTypes.Add(PersonType.EnemyTank);
        
        ShuffleSpawns();
        
        LevelEvents.Current.OnLevelChanged += SpawnEnemies;
        GameEvents.Current.OnEnemyRespawn += SetEnemyRespawnTime;
        LevelEvents.Current.OnLevelStart += SpawnPlayer;
        GameEvents.Current.OnPlayerTypeChoose += SetPlayerType;
    }

    private void Update()
    {
        RespawnEnemy();
    }
    
    public void Spawn(PersonType person)
    {
        if (_personConfs.ContainsKey(person))
        {
            _spawn = GetSpawn();
            _obj = Instantiate(_personConfs[person].Prefab, _spawn.position, _spawn.rotation);
            _personConfs[person].Controller?.AddObj(_obj);
            GameEvents.Current.EnvironmentUpdated();
        }
    }

    private void SpawnPlayer()
    {
        Spawn(_playerType);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _spawns.Count - 1; i++)
        {
            Spawn(RandomEnemyType());
        }
    }

    private void SetEnemyRespawnTime()
    {
        _time.Add(Random.Range(1f,5f));
    }

    private void RespawnEnemy()
    {
        for (int i = 0; i < _time.Count; i++)
        {
            _time[i] -= Time.deltaTime;
            if (_time[i] <= 0.0f)
            {
                _time.RemoveAt(i);
                Spawn(RandomEnemyType());
            }
        }
    }

    private void SetPlayerType(PersonType type)
    {
        _playerType = type;
    }
    private PersonType RandomEnemyType()
    {
        return _enemyTypes[Random.Range(0, _enemyTypes.Count)];
    }
    private void ShuffleSpawns()
    {
        Debug.Log("shuffled");
        for (int i = _temp.Count - 1; i >= 0; i--)
        {
            j = Random.Range(0, i + 1);
            _spawns.Enqueue(_temp[j]);
            _temp.RemoveAt(j);
        }
    }

    private Transform GetSpawn()
    {
        if (_spawns.Count > 0)
        {
            _spawn = _spawns.Dequeue();
            _spawns.Enqueue(_spawn);
            return _spawn;
        }
        return null;
    }
}
