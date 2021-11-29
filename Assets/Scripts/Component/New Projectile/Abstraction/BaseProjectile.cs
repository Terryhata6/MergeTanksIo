using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected List<AbstractPerk> _modList;
    public List<AbstractPerk> ModList => _modList;

    [SerializeField] protected Vector3 _defaultScale;

    [SerializeField] protected float _lifeTime = 5f;

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
        if (other.CompareTag("Enemy"))
        {
            _target = other.gameObject;
            InternaTriggerEnter(other);
        }
    }

    protected abstract void InternaTriggerEnter(Collider otherCollider);

    public void AddModification(AbstractPerk modification)
    {
        _modList.Add(modification);
    }
}
