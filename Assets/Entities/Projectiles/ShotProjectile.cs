using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectile : MonoBehaviour
{
    private GameObject _projectile;
    public GameObject Projectile => _projectile;

    private float _speed;
    public float Speed => _speed;

    void Start ()
    {
        _projectile = this.gameObject;
        Debug.Log(Projectile.name);
    }
}