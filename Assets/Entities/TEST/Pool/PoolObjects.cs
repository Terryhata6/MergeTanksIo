using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public int PoolCount;
    public bool PoolAutoExpand;

    public Projectile PoolPrefab;

    private PoolManager<Projectile> _pool;

    public List<Projectile> ListProjectile;

    private void Start ()
    {
        _pool = new PoolManager<Projectile> (PoolPrefab, PoolCount, transform);


        _pool.AutoExpand = PoolAutoExpand;

        ListProjectile = _pool.Pool;
    }

    public Projectile GetObject ()
    {
        return _pool.GetFreeObject ();

    }

    public List<Projectile> GetList()
    {
        return ListProjectile;
    }
}