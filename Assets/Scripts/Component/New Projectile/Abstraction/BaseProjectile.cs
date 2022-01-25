using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected List<AbstractPerk> _modList = new List<AbstractPerk>();
    public List<AbstractPerk> ModList => _modList;

    [SerializeField] protected Vector3 _defaultScale;

    [SerializeField] protected float _lifeTime;

    [SerializeField] protected GameObject _target;
    public GameObject Target => _target;

    private GameObject _idParent;

    [SerializeField] private bool _circlePerkActivate;
    public bool CirclePerkActivate => _circlePerkActivate;

    private bool _ricoshetIsActive;

    private void Start()
    {
        _lifeTime = 3f;
    }

    public void SetIdParent(GameObject idParent)
    {
        _idParent = idParent;
    }

    public void SetRicoshetIsActive(bool flag)
    {
        _ricoshetIsActive = flag;
    }


    private void OnEnable()
    {
        //_modList = new List<BaseProjectilePerk>();
        _ricoshetIsActive = false;
        StartCoroutine(LifeTime(_lifeTime));
        // Invoke("Coroutine", _lifeTime);
        //StartCoroutine(Coroutine());
    }

    // private void Coroutine()
    // {
    //     Disable();
    // }

    private void Disable()
    {
        if (_circlePerkActivate == false)
        {
            gameObject.SetActive(false);
            _target = null;
            RemoveBaseProjectile();
            _modList.Clear();
            RemoveDebuffList();

            // if (_modList == null) return;
            // _modList = null;
        }
    }

    public void RemoveBaseProjectile()
    {
        GameEvents.Current.RemoveBaseProjectile(this);
        gameObject.transform.position = new Vector3(-99f, -99f, -99f);
        gameObject.transform.localScale = _defaultScale;
    }

    public void SetCirclePerkActivate(bool flag)
    {
        _circlePerkActivate = flag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_idParent == other.gameObject) return;
        if (other.gameObject.layer.Equals((int) Layers.Enemies) ||
            other.gameObject.layer.Equals((int) Layers.Players))
        {
            _target = other.gameObject;
            if (other.gameObject.TryGetComponent(out BasePersonView target))
            {
                foreach (var projectileDebuff in _debuffList)
                {
                    projectileDebuff.ActivateModification(this);
                    target.AddDebuffList(projectileDebuff);
                }

            }
            foreach (var mod in _modList)
            {
                mod.ActivateHit(this, _target);
            }
            InternalTriggerEnter(other);
            Disable();
        }
        // if (_ricoshetIsActive)
        // {
        //     Invoke("Coroutine", _lifeTime);
        // }
        // else
        // {
        //     Disable();
        // }
    }

    protected abstract void InternalTriggerEnter(Collider otherCollider);

    public void AddModification(AbstractPerk modification)
    {
        if (modification == null) return;
        if (modification.ModificationType == AbstractPerk.TypeModification.Modification)
        {
            _modList.Add(modification);
            modification.ActivateModification(this);
        }
        else if (modification.ModificationType == AbstractPerk.TypeModification.Debuff)
        {
            AddDebuffList(modification);
        }
        // else if (modification.ModificationType == BaseProjectilePerk.TypeModification.Buff)
        // {
        //     // TODO AddBuffList(modification);
        // }
    }


    //Debuff 
    [SerializeField] private List<AbstractPerk> _debuffList = new List<AbstractPerk>();

    private void AddDebuffList(AbstractPerk debuff)
    {
        _debuffList.Add(debuff);
    }
    private void RemoveDebuffList()
    {
        _debuffList.Clear();
    }

    private IEnumerator LifeTime(float lifetime)
    {
        while (lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
            yield return null;
        }
        Disable();
    }
    //<<END
}