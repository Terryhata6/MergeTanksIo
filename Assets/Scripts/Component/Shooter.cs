using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speedProjectile = 10;
    public float SpeedProjectile => _speedProjectile;

    [SerializeField] private float _damage = 10;
    public float Damage => _damage;

    [SerializeField] private bool _isShooting;
    private bool _sequentialShots;
    public bool SequentialShots => _sequentialShots;
    [SerializeField] private float _shootInterval = 1.0f;
    public float ShootInterval => _shootInterval;
    private float _tempInterval;

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
        GameEvents.Current.OnRemoveProjectile += RemoveProjectile;
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
                _projectileList.Add(ShootPooledProjectile(_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation, perks));

            }
            //_tempInterval -= _shootInterval;
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

    // public void Shooting ()
    // {
    //     // while (true)
    //     // {
    //     if (_isShooting)
    //     {
    //         _projectileTransList = _player.ShotProjectileTransform;
    //         for (int i = 0; i < _projectileTransList.Count; i++)
    //         {
    //             _projectileList.Add (ShootPooledProjectile (_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation));
    //         }
    //         // yield return new WaitForSeconds (_shotInterval);
    //     }

    //     if (_sequentialShots)
    //     {
    //         _projectileTransList = _player.ShotProjectileTransform;
    //         for (int i = 0; i < _projectileTransList.Count; i++)
    //         {
    //             _projectileList.Add (ShootPooledProjectile (_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation));
    //             // yield return new WaitForSeconds (_shotInterval / _projectileTransList.Count);
    //         }
    //         // yield return new WaitForSeconds (_shotInterval);
    //     }
    //     // yield return new WaitForEndOfFrame ();
    //     // }
    // }


    private Projectile ShootPooledProjectile(Vector3 position, Quaternion rotation, List<AbstractPerk> perks)
    {
        _temporalProjectile = _pool.GetObject();
        _temporalProjectile.transform.position = position;
        _temporalProjectile.transform.rotation = rotation;
        _temporalProjectile.SetSpeed(SpeedProjectile);
        _temporalProjectile.SetDamage(Damage);
        foreach (var item in perks)
        {
             _temporalProjectile.AddModification(item);
        }
        return _temporalProjectile;
    }

    public void SetShootInterval(float speedInterval)
    {
        _shootInterval = speedInterval;
    }

    public void SetFlag(bool flag)
    {
        _sequentialShots = flag;
    }

    public void AddProjectile(Projectile projectile)
    {
        if (!_projectileList.Contains(projectile))
        {
            _projectileList.Add(projectile);
        }
    }

    public void RemoveProjectile(Projectile projectile)
    {
        if (_projectileList.Contains(projectile))
        {
            _projectileList.Remove(projectile);
        }
    }
}