using System.Collections.Generic;
using UnityEngine;

public class CollectableController : BaseController
{
    private Particles _particle;
    private CollectableItem _temp;
    private ObjectPool<CollectableItem> _pool;    
    private List<CollectableItem> _activeColl;
    private ParticleSystem.Particle[] _coll;
    private int _num = 0;
    private int _index;

    public override void Initialize()
    {
        LevelEvents.Current.OnLevelChanged += PoolInit;
        LevelEvents.Current.OnItemCollected += SetMovingCoin;

        _pool = new ObjectPool<CollectableItem>();
        _activeColl = new List<CollectableItem>();
        _coll = new ParticleSystem.Particle[_particle?.System.main.maxParticles ?? 0];
        PoolInit();
    }

    public override void Execute()
    {
        FindBirthParticle();                // поиск только что родившихся партиклов
        for (int i = 0; i < _activeColl.Count; i++)
        {
            if (CheckActive(i))  // проверка на то, что движущийся coin все еще активен и не достиг своей цели
            {
                MoveCollectable(_activeColl[i]); // движение coin
            }
        }
    }

    private void PoolInit()
    {
        Debug.Log("pOOL INIT");
        if (_particle != null)
        _pool.Initialize(_particle.Prefabs, _particle.System.main.maxParticles);
    }

    private void FindBirthParticle()
    {
        for (_index = 0; _index < _num; _index++)
        {
            if (_coll[_index].remainingLifetime == _particle.System.main.startLifetimeMultiplier) // при рождении партикла на его месте помещается coin
            {
                _temp = _pool.GetObject();
                _temp.transform.position = _coll[_index].position + Vector3.up * 0.5f;
                _temp.gameObject.layer = 6;
                _temp.gameObject.tag = "Collectable";
            }
        }
        _num = _particle?.System.GetParticles(_coll) ?? 0;
    }

    private void MoveCollectable(CollectableItem col)
    {
        col.transform.position = Vector3.MoveTowards(col.transform.position, col.Target.position + Vector3.up * 0.5f, Time.deltaTime * 2f);
    }

    private bool CheckActive(int num)
    {
        if (_activeColl[num].enabled == false)
        {
            _activeColl.RemoveAt(num);
            return false;
        }
        return true;
    }

    private void SetMovingCoin(CollectableItem coin) // Установка движущегося coin(когда игрок подбирает коин он движется к игроку)
    {
        _activeColl.Add(coin);
    }

    public void SetParticles(Particles ps)
    {
        Debug.Log("pARTICLES Set");
        _particle = ps;
    }
}
