using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shooter : AbstractShooter
{
    #region Shooter Params
    [SerializeField] private float _speedProjectile = 30f;
    public float SpeedProjectile => _speedProjectile;

    [SerializeField] private float _damage = 10f;
    public float Damage => _damage;
    [SerializeField] private bool _sequentialShots;
    public bool SequentialShots => _sequentialShots;
    [SerializeField] private float _shootInterval = 1f;
    public float ShootInterval => _shootInterval;
    private float _tempInterval;
    #endregion

    private ObjectPool<Projectile> _pool;
    public ObjectPool<Projectile> Pool => _pool;
    private BasePersonView _basePlayer; //<<
    private Projectile _temporalProjectile;

    [SerializeField] private List<Projectile> _projectileList;
    public List<Projectile> ProjectileList => _projectileList;

    private ProjectileController _projectileController;

    private List<AbstractPerk> _perkProjectileList;
    public List<AbstractPerk> PerkProjectileList => _perkProjectileList;

    public void Init(BasePersonView basePerson) //IEnumerator Start
    {
        _basePlayer = basePerson;
        _ownGameObject = _basePlayer.gameObject;
        TankShotProjectileRecordTransform(_ownGameObject);
        _projectileController = MainController.Current.GetController<ProjectileController>();
        _projectileController.AddShooterToList(this);
        _pool = _projectileController.Pool;
        GameEvents.Current.OnRemoveBaseProjectile += RemoveProjectile;
    }

    public void Shooting(List<AbstractPerk> perks)
    {
        _perkProjectileList = perks;
        if (!_sequentialShots)
        {
            Volley(perks);
        }
        else
        {
            // TODO
            // Sequential();
        }

    }

    private void Volley(List<AbstractPerk> perks)
    {
        _tempInterval += Time.deltaTime;
        if (_tempInterval >= _shootInterval)
        {
            for (int i = 0; i < _shotProjectileTransform.Count; i++)
            {
                _temporalProjectile = ShootPooledProjectile(_shotProjectileTransform[i].transform.position, _shotProjectileTransform[i].transform.rotation);
                if (_temporalProjectile == null) return;
                _temporalProjectile = ProjectileModification();
                AddProjectile(_temporalProjectile);
            }
            _tempInterval = 0;
        }
    }

    private Projectile ShootPooledProjectile(Vector3 position, Quaternion rotation)
    {
        _temporalProjectile = _pool.GetObject();
        if (_temporalProjectile == null) return _temporalProjectile;
        _temporalProjectile.transform.position = position;
        _temporalProjectile.transform.rotation = rotation;
        _temporalProjectile.SetIdParent(_ownGameObject);

        return _temporalProjectile;
    }

    private Projectile ProjectileModification()
    {
        _temporalProjectile.ChangeSpeed(SpeedProjectile);
        _temporalProjectile.ChangeDamage(Damage);

        if (_perkProjectileList == null) return _temporalProjectile;

        foreach (var perkProjectile in _perkProjectileList)
        {
            _temporalProjectile.AddModification(perkProjectile);
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

        if (projectile is Projectile && _pool!.Equals(null))
        {
            _pool.AddObject(projectile as Projectile);
        }

    }

    public void MoveProjectile()
    {
        for (int i = 0; i < _projectileList.Count; i++)
        {
            _projectileList[i].Move();
        }
    }

    #region Circle Projectile
    [SerializeField] private float _speed;
    private GameObject _circleProjectileWeapon;
    public void RotationCircleProjectile()
    {
        if (_circleProjectileWeapon == null) return;
        if (_ownGameObject == null) return;

        _circleProjectileWeapon.transform.position = _ownGameObject.transform.position;
        _circleProjectileWeapon.transform.Rotate(Vector3.up * Time.deltaTime * _speed);
    }

    public void SetCircleProjectileWeapon(GameObject go)
    {
        _circleProjectileWeapon = go;
    }
    #endregion
}