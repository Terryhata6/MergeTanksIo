using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected List<AbstractPerk> _modList;
    public List<AbstractPerk> ModList => _modList;

    [SerializeField] protected Vector3 _defaultScale;

    [SerializeField] protected float _lifeTime;

    [SerializeField] protected GameObject _target;
    public GameObject Target => _target;

    private GameObject _idParent;

    private void Start()
    {
        transform.localScale = _defaultScale;
    }

    public void SetIdParent(GameObject idParent)
    {
        _idParent = idParent;
    }

    private void OnEnable()
    {
        _modList = new List<AbstractPerk>();
        Invoke("Coroutine", _lifeTime);
    }

    private void Coroutine()
    {
        Disable();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
        _target = null;
        RemoveBaseProjectile();
        if (_modList == null) return;
        _modList = null;
    }

    public void RemoveBaseProjectile()
    {
        GameEvents.Current.RemoveBaseProjectile(this);
        gameObject.transform.position = new Vector3(-99f, -99f, -99f);
        gameObject.transform.localScale = _defaultScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_idParent == other.gameObject) return;
        Debug.Log("PArent: " + _idParent);
        Debug.Log("Collider: " + other.gameObject);
        if (other.gameObject.layer.Equals((int) Layers.Enemies) ||
            other.gameObject.layer.Equals((int) Layers.Players))
        {
            _target = other.gameObject;
            InternalTriggerEnter(other);
            Disable();
        }
    }

    protected abstract void InternalTriggerEnter(Collider otherCollider);

    public void AddModification(AbstractPerk modification)
    {
        _modList.Add(modification);
    }
}