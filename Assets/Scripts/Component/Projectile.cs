using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private List<AbstractDecorator> _providerList; //<< Test
    private float _speed;
    private float _newSpeed = 0f;

    private float _damage;
    private float _delay = 5f;


    private void OnEnable()
    {
        Invoke("DisableProjectileCoroutine", _delay);
    }

    // Test
    private void Start()
    {
        // _providerList = new List<AbstractDecorator>();
        // var t = ScriptableObject.CreateInstance<RepulsiveProjectilesPerk>();
        // var z = ScriptableObject.CreateInstance<RicochetPerk>();
        // _providerList.Add(t);
        // _providerList.Add(z);
    }
    //..End

    public void MoveProjectile()
    {
        _newSpeed = _speed * Time.deltaTime;
        transform.Translate(transform.forward * _newSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //Enemy
        {
            if (_providerList == null || _providerList.Count == 0)
            {
                //DisableProjectile ();
            }
            else
            {
                foreach (var item in _providerList)
                {
                    item.Active(this, other.gameObject);
                }
            }
        }
    }

    private void DisableProjectileCoroutine()
    {
        DisableProjectile();
    }

    private void DisableProjectile()
    {
        _providerList = null;
        gameObject.SetActive(false);
        RemoveProjectile();
    }

    public void RemoveProjectile()
    {
        GameEvents.Current.RemoveProjectile(this);
        gameObject.transform.position = new Vector3(-99f, -99f, -99f);
    }

    public void AddModification(AbstractDecorator modification) //<< Test
    {
        _providerList.Add(modification);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}