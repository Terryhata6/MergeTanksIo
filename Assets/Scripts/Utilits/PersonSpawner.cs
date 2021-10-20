
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _temp;
    private Queue<Transform> _spawns;
    private Dictionary<PersonType, PersonConf> _personConfs;
    private GameObject _dino;
    private GameObject _tank;
    private GameObject _obj;
    private Transform _spawn;
    private int j;
    private void Start()
    {
        _dino = Resources.Load<GameObject>("Dino");
        _tank = Resources.Load<GameObject>("Tank");
        
        _personConfs = new Dictionary<PersonType, PersonConf>();
        _personConfs.Add(PersonType.EnemyDino,
            new PersonConf(FindObjectOfType<MainController>().GetController<EnemyController>(), _dino));
        _personConfs.Add(PersonType.EnemyTank,
            new PersonConf(FindObjectOfType<MainController>().GetController<EnemyController>(), _tank));
        _personConfs.Add(PersonType.PlayerDino,
            new PersonConf(FindObjectOfType<MainController>().GetController<PlayerController>(), _dino));
        _personConfs.Add(PersonType.PlayerTank,
            new PersonConf(FindObjectOfType<MainController>().GetController<PlayerController>(), _tank));

        _spawns = new Queue<Transform>();
        ShuffleSpawns();
        

        LevelEvents.Current.OnLevelStarted += SpawnEnemies;
    }

    public void Spawn(PersonType person)
    {
        if (_personConfs.ContainsKey(person))
        {
            _obj = Instantiate(_personConfs[person].Prefab, GetSpawn().position, GetSpawn().rotation);
            _personConfs[person].Controller?.AddObj(_obj);
        }
        
    }

    public void SpawnEnemies()
    {
        Debug.Log(_spawns.Count);
        for (int i = 0; i < _spawns.Count - 1; i++)
        {
            Spawn(RandomEnemyType());
        }
    }

    private PersonType RandomEnemyType()
    {
        return (PersonType) Random.Range((int) PersonType.EnemyTank, (int) PersonType.EnemyDino + 1);
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
            _spawns.Enqueue((_spawn));
            return _spawn;
        }
        return null;
    }
}
