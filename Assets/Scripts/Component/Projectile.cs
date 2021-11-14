using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private List<AbstractPerk> _modList;
    public List<AbstractPerk> ModList => _modList;
    private float _speed;
    private float _newSpeed = 0f;

    private float _damage;
    private float _delay = 5f;
    private bool _isHit = false;
    public bool IsHit => _isHit;

    private GameObject _target;
    public GameObject Target => _target;

    private void OnEnable()
    {
        _modList = new List<AbstractPerk>();
        Invoke("DisableProjectileCoroutine", _delay);
    }

    public void MoveProjectile()
    {
        _newSpeed = _speed * Time.deltaTime;
        transform.Translate(transform.forward * _newSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //Enemy
        {

            ITakeDamage enemy = other.gameObject.GetComponent<ITakeDamage>();
            if (enemy != null) enemy.TakeDamage(_damage);



            if (_modList == null || _modList.Count == 0) return;
            if (other.gameObject == null) return;
            _isHit = true;
            if (_isHit) _target = other.gameObject;
            if (_target == null) return;

            foreach (var mod in _modList)
            {
                // mod.Activate(this, other.gameObject);
            }
        }
    }

    private void DisableProjectileCoroutine()
    {
        DisableProjectile();
    }

    private void DisableProjectile()
    {
        gameObject.SetActive(false);
        _isHit = false;
        RemoveProjectile();
        if (_modList == null) return;
        _modList = null;
    }

    public void RemoveProjectile()
    {
        GameEvents.Current.RemoveProjectile(this);
        gameObject.transform.position = new Vector3(-99f, -99f, -99f);
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public void AddModification(AbstractPerk modification) //<< Test
    {
        // modification.Activate(this);
        // modification.AddLevel();
        _modList.Add(modification);
        foreach (var item in _modList)
        {
            item.Activate(this);
        }
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