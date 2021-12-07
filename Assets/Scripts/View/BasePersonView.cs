using System.Collections.Generic;
using UnityEngine;

public abstract class BasePersonView : BaseObjectView, IApplyDamage, IDead
{
    #region {Author:Doonn}
    [SerializeField] protected PerkManager _perkManager;
    public PerkManager PerkManager => _perkManager;

    #region Fields
    private Shooter _shooter;
    // Player Level Up
    [SerializeField, Range(1, 5)] private int _level = 1;
    public int Level => _level;

    // Shot Project Transform
    [SerializeField] private List<Transform> _shotProjectileTransform;
    public List<Transform> ShotProjectileTransform => _shotProjectileTransform;

    #endregion

    [SerializeField] private List<GameObject> _tankMeshes;

    #endregion

    #region Player Params
    [SerializeField] private ViewParamsComponent _viewParams = new ViewParamsComponent();
    public ViewParamsComponent ViewParams => _viewParams;
    #endregion

    private Mesh _mesh;
    private Bounds[] _bounds;
    [SerializeField] private float _boundSize;
    private SphereCollider _sphereColl;

    #region {Author:Doonn}
    public void Awake()
    {
        _bounds = new Bounds[_tankMeshes.Count];

        _sphereColl = GetComponent<SphereCollider>();
        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            _bounds[i] = _tankMeshes[i].GetComponent<MeshFilter>().mesh.bounds;
        }

        InitColliderCenterAndSize();
        TankShotProjectileRecordTransform();
    }

    private void InitColliderCenterAndSize()
    {
        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            if (_tankMeshes[i].activeSelf)
            {
                _sphereColl.radius = (_bounds[i].size.x / 2);
                _sphereColl.center = new Vector3(0, _bounds[i].size.x / 2 , 0);
            }
        }
    }

    public void InitializeShooter(Shooter shooter)
    {
        _shooter = shooter;
        _perkManager = new PerkManager(_viewParams, _shooter);
    }

    public void ChangeTankMesh(int index)
    {
        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            _tankMeshes[i].SetActive(false);
        }

        _tankMeshes[index - 1].SetActive(true);
        InitColliderCenterAndSize();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals((int) Layers.Collectables))
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                other.gameObject.SetActive(false);
                if (CheckTankMeshesList(_tankMeshes) == false) return;
                if (_tankMeshes.Count < 5) return;
                if (Level >= 5) return; // << Хард Код (Level >= 5)

                _level++;
                ChangeTankMesh(Level);

                TankShotProjectileRecordTransform();
            }

        }
    }

    // Запись Трансформов от куда вылетают Снаряды
    public void TankShotProjectileRecordTransform()
    {
        if (_tankMeshes == null) return;
        bool checkListIsEmpty = _tankMeshes.TrueForAll(x => x != null);

        if (!checkListIsEmpty)
        {
            Debug.Log("List Slot Empty");
            return;
        }


        foreach (GameObject Tank in _tankMeshes)
        {
            if (Tank.activeInHierarchy)
            {
                _shotProjectileTransform.Clear();
                int CountChild = Tank.transform.childCount;
                for (int i = 0; i < CountChild; i++)
                {
                    _shotProjectileTransform.Add(Tank.transform.GetChild(i));
                }
            }
        }
    }

    private bool CheckTankMeshesList(List<GameObject> tankMeshes)
    {
        if (tankMeshes.Count == 0) return false;

        foreach (var item in tankMeshes)
        {
            if (item == null) return false;
        }
        return true;
    }

    public void Attack()
    {
        if (_shooter == null) return;
        _shooter.Shooting(_perkManager.OwnShooterPerkList);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Нанес Повреждение");
        ViewParams.ChangeHealth(ViewParams.Health - damage);
        IsDead();
    }

    public void IsDead()
    {
        if (ViewParams.IsDead())
        {
            Debug.Log(GetType().ToString() + " DEAD");
            Destroy(gameObject);
        }
    }
    #endregion
}