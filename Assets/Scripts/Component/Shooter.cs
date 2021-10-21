using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speedProjectile = 15;
    public float SpeedProjectile => _speedProjectile;

    [SerializeField] private float _damage = 10;
    public float Damage => _damage;

    [SerializeField] private bool _isShooting;
    private bool _sequentialShots;
    public bool SequentialShots => _sequentialShots;
    [SerializeField] private float _shotInterval = 1.0f;
    public float ShotInterval => _shotInterval;
    private float _tempInterval;

    private ObjectPool<Projectile> _pool;
    private List<Transform> _projectileTransList = new List<Transform> ();
    private PlayerView _player;
    private Projectile _temporalProjectile;

    private List<Projectile> _projectileList = new List<Projectile> ();
    public List<Projectile> ProjectileList => _projectileList;

    private ProjectileController _projectileController;

    private void Start ()
    {


        if (TryGetComponent (out _player))
        {
            // Добавитсь контроллер ProjectileController
            _projectileController = GameObject.FindObjectOfType<MainController> ().GetController<ProjectileController> ();
            _projectileController.AddShooterToList (this);
            _player.InitializeShooter (this);
            _pool = _projectileController.Pool;
            Debug.Log (_pool);
            // StartCoroutine (Shooting ());
        }
        else
        {
            Debug.Log ("PlayerView not found", this.gameObject);
            return;
        }
    }

    public void Shooting (List<AbstractPerk> perks)
    {

        if (!_sequentialShots)
        {
            Volley ();
        }
        else
        {
            Sequential ();
        }

    }

    private void Volley ()
    {
        _tempInterval += Time.deltaTime;
        if (_tempInterval >= _shotInterval)
        {
            _projectileTransList = _player.ShotProjectileTransform;
            for (int i = 0; i < _projectileTransList.Count; i++)
            {
                _projectileList.Add (ShootPooledProjectile (_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation));
            }
            _tempInterval -= _shotInterval;
        }
    }

    private void Sequential ()
    {
        _projectileTransList = _player.ShotProjectileTransform;
        for (int i = 0; i < _projectileTransList.Count; i++)
        {
            _tempInterval += Time.deltaTime;
            while (_tempInterval >= _shotInterval / _projectileTransList.Count)
            {
                _projectileList.Add (ShootPooledProjectile (_projectileTransList[i].transform.position, _projectileTransList[i].transform.rotation));
                _tempInterval = 0;
            }

        }


    }

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


    private Projectile ShootPooledProjectile (Vector3 position, Quaternion rotation)
    {
        _temporalProjectile = _pool.GetObject ();
        _temporalProjectile.transform.position = position;
        _temporalProjectile.transform.rotation = rotation;
        _temporalProjectile.SetSpeed (SpeedProjectile);
        _temporalProjectile.SetDamage (Damage);
        return _temporalProjectile;
    }

    public void SetShotInterval (float speedInterval)
    {
        _shotInterval = speedInterval;
    }

    public void SetFlag (bool flag)
    {
        _sequentialShots = flag;
    }
}