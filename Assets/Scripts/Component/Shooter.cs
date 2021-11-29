using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    #region Shooter Params
    [SerializeField] private float _speedProjectile = 10;
    public float SpeedProjectile => _speedProjectile;

    [SerializeField] private float _damage = 10;
    public float Damage => _damage;
    [SerializeField] private bool _sequentialShots;
    public bool SequentialShots => _sequentialShots;
    [SerializeField] private float _shootInterval = 1.0f;
    public float ShootInterval => _shootInterval;
    private float _tempInterval;
    #endregion

    private ObjectPool<Projectile> _pool;
    public ObjectPool<Projectile> Pool => _pool;
    private List<Transform> _projectileTransList = new List<Transform>();
    private PlayerView _player;
    private Projectile _temporalProjectile;

    [SerializeField] private List<Projectile> _projectileList;
    public List<Projectile> ProjectileList => _projectileList;

    private ProjectileController _projectileController;

    private List<AbstractPerk> _perkList;
    public List<AbstractPerk> PerkList => _perkList;

    private void Start()
    {
        if (TryGetComponent(out _player))
        {
            _projectileController = GameObject.FindObjectOfType<MainController>().GetController<ProjectileController>();
            _projectileController.AddShooterToList(this);
            _player.InitializeShooter(this);
            _pool = _projectileController.Pool;
            Debug.Log(_pool);
        }
        else
        {
            Debug.Log("PlayerView not found", this.gameObject);
            return;
        }
        GameEvents.Current.OnRemoveBaseProjectile += RemoveProjectile;
    }

    public void Shooting(List<AbstractPerk> perks)
    {
        _perkList = perks;
        if (!_sequentialShots)
        {
            Volley(perks);
        }
        else
        {
            // Sequential();
        }

    }
    
    private void Volley(List<AbstractPerk> perks)
    {
        _tempInterval += Time.deltaTime;
        if (_tempInterval >= _shootInterval)
        {
            _projectileTransList = _player.ShotProjectileTransform;
            for (int i = 0; i < _projectileTransList.Count; i++)
            {
                _temporalProjectile = ShootPooledProjectile(_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation);
                _temporalProjectile = ProjectileModification();
                AddProjectile(_temporalProjectile);
            }
            _tempInterval = 0;
        }
    }

    // private void Sequential()
    // {
    //     _projectileTransList = _player.ShotProjectileTransform;
    //     for (int i = 0; i < _projectileTransList.Count; i++)
    //     {
    //         _tempInterval += Time.deltaTime;
    //         while (_tempInterval >= _shootInterval / _projectileTransList.Count)
    //         {
    //             _projectileList.Add(ShootPooledProjectile(_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation));

    //             _tempInterval = 0;
    //         }

    //     }
    // }

    private Projectile ShootPooledProjectile(Vector3 position, Quaternion rotation)
    {
        _temporalProjectile = _pool.GetObject();
        _temporalProjectile.transform.position = position;
        _temporalProjectile.transform.rotation = rotation;

        return _temporalProjectile;
    }

    private Projectile ProjectileModification()
    {
        _temporalProjectile.ChangeSpeed(SpeedProjectile);
        _temporalProjectile.ChangeDamage(Damage);

        if (_perkList == null) return _temporalProjectile;

        foreach (var item in _perkList)
        {
            _temporalProjectile.AddModification(item);
        }
        return _temporalProjectile;
    }

    public void ChangeShootInterval(float speedInterval)
    {
        _shootInterval = speedInterval;
    }

    public void AddProjectile(Projectile projectile)
    {
        if (!_projectileList.Contains(projectile))
        {
            _projectileList.Add(projectile);
        }
    }

    public void RemoveProjectile(BaseProjectile projectile)
    {
        if (_projectileList.Contains((Projectile) projectile))
        {
            _projectileList.Remove((Projectile) projectile);
        }
    }

    public void MoveProjectile()
    {
        for (int i = 0; i < _projectileList.Count; i++)
        {
            _projectileList[i].Move();
        }
    }
}