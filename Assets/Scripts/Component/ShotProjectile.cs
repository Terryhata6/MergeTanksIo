using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotProjectile : MonoBehaviour
{
    private float _speed = 15;
    public float Speed => _speed;

    [SerializeField] private bool _isShooting;
    [SerializeField] private bool _sequentialShots;
    [SerializeField] private float _delay = 1f;
    
    private ObjectPool<Projectile> _pool;
    private List<Transform> _obj;
    private PlayerView _player;
    private Projectile _temporalProjectile;
    
    public void SetObjectPools(ObjectPool<Projectile> pool)
    {
        _pool = pool;
    }

    private void Start ()
    {
        if (TryGetComponent(out _player))
        {
            StartCoroutine (Shooting ());
        }
        else
        {
            Debug.Log("PlayerView not found", this.gameObject);
            return;
        }
    }

    IEnumerator Shooting ()
    {
        while (true)
        {
            List<Transform> obj = new List<Transform> ();
            if (_isShooting)
            {
                obj = _player.ShotProjectileTransform;
                for (int i = 0; i < obj.Count; i++)
                {
                    ShootPooledProjectile(obj[i].transform.position, obj[i].transform.rotation);
                }
                yield return new WaitForSeconds (_delay);
            }

            if (_sequentialShots)
            {
                obj = _player.ShotProjectileTransform;
                for (int i = 0; i < obj.Count; i++)
                {
                    ShootPooledProjectile(obj[i].transform.position, obj[i].transform.rotation);
                    yield return new WaitForSeconds (_delay / obj.Count);
                }
                yield return new WaitForSeconds (_delay);
            }
            yield return new WaitForEndOfFrame ();
        }
    }

    
    private Projectile ShootPooledProjectile(Vector3 position, Quaternion rotation)
    {
        _temporalProjectile = _pool.GetObject();
        _temporalProjectile.transform.position = position;
        _temporalProjectile.transform.rotation = rotation;
        return _temporalProjectile;
    }
}