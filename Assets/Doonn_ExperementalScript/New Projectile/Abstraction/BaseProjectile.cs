using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] private List<AbstractPerk> _modList;
    public List<AbstractPerk> ModList => _modList;

    [SerializeField] private Vector3 _defaultScale;

    [SerializeField] private float _lifeTime = 5f;

    protected GameObject _target;
    public GameObject Target => _target;

    private void Start()
    {
        transform.localScale = _defaultScale;
    }

    private void OnEnable()
    {
        _modList = new List<AbstractPerk>();
        Invoke("Coroutine", _lifeTime);
    }

    private void Disable()
    {
        gameObject.SetActive(false);

        RemoveBaseProjectile();
        if (_modList == null) return;
        _modList = null;
    }

    private void Coroutine()
    {
        Disable();
    }

    public void RemoveBaseProjectile()
    {
        GameEvents.Current.RemoveBaseProjectile(this);
        gameObject.transform.position = new Vector3(-99f, -99f, -99f);
        gameObject.transform.localScale = _defaultScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Попал Во Врага");
            InternaTriggerEnter(other);
        }
    }

    protected abstract void InternaTriggerEnter(Collider otherCollider);

    public void AddModification(AbstractPerk modification) //<< Test
    {
        _modList.Add(modification);
        foreach (var item in _modList)
        {
            // item.Activate(this);
        }
    }
}