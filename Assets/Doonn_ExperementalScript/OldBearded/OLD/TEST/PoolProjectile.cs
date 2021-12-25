using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolProjectile : MonoBehaviour
{
    private ObjectPool<Projectile> _projectiles = new ObjectPool<Projectile> ();
    public Projectile Projectile;
    private void Start ()
    {
        var tt = GameObject.FindObjectOfType<Projectile> ();
        _projectiles.Initialize (Projectile, 100);
    }

    public Projectile GetProjectile ()
    {
        return _projectiles.GetObject();
    }
}