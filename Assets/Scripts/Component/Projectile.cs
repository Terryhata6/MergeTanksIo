using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private float _damage;
    private float _newSpeed;

    public void MoveProjectile ()
    {
        _newSpeed = _speed * Time.deltaTime;
        transform.Translate (transform.forward * _newSpeed, Space.World);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Debug.Log("Попадание");
            ReturnProjectileToPull();
        }
    }

    public void ReturnProjectileToPull()
    {

    }
}