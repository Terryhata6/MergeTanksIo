using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public abstract class BasePersonView : BaseObjectView, IApplyDamage, IDead
{
    [SerializeField] protected int _points;  //EnterAlt
    public int Points => _points; //EnterAlt
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

    #region {Author:Doonn}
    public void Awake()
    {
        _level = 1;
        TankShotProjectileRecordTransform();
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
    }
//Enter Alt
    public virtual void OnTriggerEnter(Collider other)
    {
        CheckCollectable(other.gameObject);
        CheckMerge(other.gameObject);
    }
//Enter Alt
    private void CheckCollectable(GameObject other)
    {
        if (other.layer.Equals((int) Layers.Collectables) && _viewParams.IsDead() == false)
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                other.SetActive(false);
                GetPoints(other.GetComponent<CollectableItem>().Points);
            }
        }
    }
//Enter Alt
    private void CheckMerge(GameObject other)
    {
        if (other.layer.Equals((int) Layers.Merge) && _viewParams.IsDead() == false)
        {
            Debug.Log(other);
            Destroy(other);
            GetMerge();
        }
    }
//Enter Alt
    private void GetMerge()
    {
        // if (CheckTankMeshesList(_tankMeshes) == false) return;
        // if (_tankMeshes.Count < 5) return;
        // if (Level >= 5) return; // << Хард Код (Level >= 5)
        //
        // _level++;
        // ChangeTankMesh(Level);
        // TankShotProjectileRecordTransform();
        // UpParams();
    }

    private void UpParams( )
    {
        _viewParams.MaxHealth *= 1.5f;
        _viewParams.MoveSpeed *= 0.75f;
        _viewParams.RotationSpeed *= 0.75f;
    }
    
    //Enter Alt 07.12
    private void GetPoints(int points)
    {
        _points += points;
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

        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            if (_tankMeshes[i].Equals(null)) return false;
        }
        return true;
    }

    public void Attack()
    {
        if (_viewParams.IsDead().Equals(true))
        {
            return;
        }
        if (_shooter == null) return;
        _shooter.Shooting(_perkManager.OwnShooterPerkList);
    }

    public void TakeDamage(float damage)
    {
        if (_viewParams.IsDead().Equals(true))
        {
            return;
        }
        //Debug.Log("Нанес Повреждение");
        ViewParams.ChangeHealth(ViewParams.Health - damage);
        IsDead();
    }

    public virtual void IsDead()
    {
        
        if (ViewParams.IsDead())
        {
            Debug.Log(GetType().ToString() + " DEAD");
            GameEvents.Current.PersonDead(this);
            Destroy(gameObject);
        }
        
        
        
    }
    #endregion
}