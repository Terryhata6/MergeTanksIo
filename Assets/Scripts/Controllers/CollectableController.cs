using System.Collections.Generic;
using UnityEngine;

public class CollectableController : BaseController, IExecute
{
    private Particles _particle;
    private CollectableItem _temp;
    private ObjectPool<CollectableItem> _pool;    
    private List<CollectableItem> _activeColl;
    private ParticleSystem.Particle[] _coll;
    private Vector3 _particlePos;
    private float _lifeTime = 0f;
    private int _num = 0;
    private int _index;

    public override void Initialize()
    {
        LevelEvents.Current.OnLevelChanged += PoolInit;
        GameEvents.Current.OnItemCollected += SetMovingCoin;
        GameEvents.Current.OnParticlesAppear += SetParticles;
        GameEvents.Current.OnCollectableDisable += DeleteActiveCol;

        _pool = new ObjectPool<CollectableItem>();
        _activeColl = new List<CollectableItem>();
        Debug.Log("CollectableController start");
    }

    public override void Execute()
    {
        // FindBirthParticle();                // поиск только что родившихся партиклов
        // for (int i = 0; i < _activeColl.Count; i++)
        // {
        //     MoveCollectable(_activeColl[i]); // движение coin
        // }
    }

    private void PoolInit()
    {
        _pool.CleanPool();
        if (_particle)
        {
            Debug.Log("pOOL INIT");
            _pool.Initialize(_particle.Prefabs, _particle.System.main.maxParticles);
        }
    }

    private void FindBirthParticle()
    {
        for (_index = 0; _index < _num; _index++)
        {
            if (_coll[_index].remainingLifetime > _lifeTime-1 && Time.timeScale > 0) // при рождении партикла на его месте помещается coin
            {
                _temp = _pool.GetObject();
                if (_temp != null)
                {
                    if (_temp.Target == null)
                    {
                        CollectableInit(_temp);
                    }
                }
            }
        }
        if (_particle)
        {
            _num = _particle?.System.GetParticles(_coll) ?? 0;
        }

    }

    private void MoveCollectable(CollectableItem col)
    {
        Debug.Log($"{col.gameObject.name}",col.gameObject);
        if (col.enabled)
        {
            Debug.LogWarning(col.Target,col.Target);
            col.transform.position = Vector3.MoveTowards(col.transform.position, col.Target.position + Vector3.up * 0.5f, Time.deltaTime);
        }
    }

    private void CollectableInit(CollectableItem col)
    {
        col.transform.position = Vector3.right * Random.Range(-100,100) + Vector3.forward * Random.Range(-100,100) +_particlePos;
        col.gameObject.layer = (int)Layer.Collectables;
        col.tag = "Collectable";
        GameEvents.Current.EnvironmentUpdated();
    }

    private void SetMovingCoin(CollectableItem coin) // Установка движущегося coin(когда игрок подбирает коин он движется к игроку)
    {
        if (!_activeColl.Contains(coin))
        {
            _activeColl.Add(coin);
        }
    }

    private void DeleteActiveCol(CollectableItem col)
    {
        if (_activeColl.Contains(col))
        {
            _activeColl.Remove(col);
        }
        else Debug.Log("как дела");
    }

    private void SetParticles(Particles ps)
    {
        if (ps)
        {
            Debug.Log("Particles set"); 
            _particle = ps;
            _particlePos = ps.transform.position;
            _coll = new ParticleSystem.Particle[_particle?.System.main.maxParticles ?? 0];
            _lifeTime = _particle?.System.main.startLifetimeMultiplier ?? 0f;
        }
    }
}
