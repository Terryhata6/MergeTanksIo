using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerView : BaseObjectView
{
    [SerializeField] private PerkManager _perkManager; // << New Perk System
    public PerkManager PerkManager => _perkManager; // << New Perk System

    #region Fields
    private Shooter _shooter;
    public Shooter Shooter => _shooter;

    //[Header("MainStats")]

    [SerializeField] private PlayerState _state = PlayerState.Idle;

    #region {Author:Doonn}

    // Player Level Up
    [SerializeField, Range(1, 5)] private int _level = 1;
    public int Level => _level;

    // Shot Project Transform
    [SerializeField] private List<Transform> _shotProjectileTransform;
    public List<Transform> ShotProjectileTransform => _shotProjectileTransform;

    #endregion

    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private List<GameObject> _tankMeshes;

    #endregion

    #region AccsessModifyers

    public PlayerState State => _state;


    public Rigidbody Rigidbody => _playerRigidbody;

    #endregion

    #region Player Params
    // [SerializeField] private ViewParamsStruct _viewParams;
    // public ViewParamsStruct ViewParams => _viewParams;

    [SerializeField] private ViewParamsComponent _viewParams = new ViewParamsComponent();
    public ViewParamsComponent ViewParams => _viewParams;
    #endregion

    public void Awake()
    {
        if (_playerRigidbody == null)
            _playerRigidbody = GetComponent<Rigidbody>();

        TankShotProjectileRecordTransform();
    }

    // Start is called before the first frame update

    void Start()
    {


    }

    public void InitializeShooter(Shooter shooter)
    {
        _shooter = shooter;
        _perkManager = new PerkManager(_viewParams, _shooter);
    }

    public void SetState(PlayerState state)
    {
        _state = state;
    }

    public void ChangeTankMesh(int index)
    {
        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            _tankMeshes[i].SetActive(false);
        }

        _tankMeshes[index - 1].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int) Layer.Collectables)
        {
            if ((other.transform.position - transform.position).magnitude < 2f)
            {
                other.gameObject.SetActive(false);
            }
            if (CheckTankMeshesList(_tankMeshes) == false) return;
            if (_tankMeshes.Count < 5) return;
            if (Level >= 5) return; // << Хард Код (Level >= 5)

            _level++;
            ChangeTankMesh(Level);

            TankShotProjectileRecordTransform();
        }
    }

    #region {Author:Doonn}
    // Запись Трансформов от куда вылетают Снаряды
    public void TankShotProjectileRecordTransform()
    {
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
        _shooter.Shooting(_perkManager.OwnShooterPerkList);
    }

    #endregion
}