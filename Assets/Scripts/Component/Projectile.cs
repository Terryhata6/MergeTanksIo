using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    private ProjectileController _projectileController;
    public void MoveProjectile ()
    {
        float newSpeed = Speed * Time.deltaTime;
        transform.Translate (transform.forward * newSpeed, Space.World);
    }
}