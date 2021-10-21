using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerView : BaseObjectView
{
    #region Fields
    private Shooter _shooter;

    //[Header("MainStats")]
    [SerializeField] private List<AbstractPerk> _perkList;

    [SerializeField] private PlayerState _state = PlayerState.Idle;

    #region {Author:Doonn}

    // Player Level Up
    [SerializeField, Range (1, 5)] private int _level = 1;
    public int Level => _level;

    // Attack Range
    private float _attackRange; //<< 0
    public float AttackRange => _attackRange; //<< 0

    // Shot Project Transform
    [SerializeField] private List<Transform> _shotProjectileTransform;
    public List<Transform> ShotProjectileTransform => _shotProjectileTransform;

    #endregion

    [SerializeField, Range (3f, 10f)] private float _movementSpeed = 3.0f;

    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private List<GameObject> _tankMeshes;

    #endregion

    #region AccsessModifyers

    public float MovementSpeed => _movementSpeed;


    public PlayerState State => _state;


    public Rigidbody Rigidbody => _playerRigidbody;

    #endregion

    public void Awake ()
    {
        if (_playerRigidbody == null)
            _playerRigidbody = GetComponent<Rigidbody> ();

        TankShotProjectileRecordTransform ();
    }

    // Start is called before the first frame update

    void Start () { }
    public void InitializeShooter (Shooter shooter)
    {
        _shooter = shooter;
    }

    public void SetState (PlayerState state)
    {
        _state = state;
    }

    public void ChangeTankMesh (int index)
    {
        for (int i = 0; i < _tankMeshes.Count; i++)
        {
            _tankMeshes[i].SetActive (false);
        }

        _tankMeshes[index - 1].SetActive (true);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag ("Collectable"))
        {

            if (CheckTankMeshesList (_tankMeshes) == false) return;
            if (_tankMeshes.Count < 5) return;
            if (Level >= 5) return; // << Хард Код (Level >= 5)

            _level++;
            ChangeTankMesh (Level);

            TankShotProjectileRecordTransform ();

            other.gameObject.SetActive (false);
        }
    }



    #region {Author:Doonn}

    // Запись Трансформов от куда вылетают Снаряды
    public void TankShotProjectileRecordTransform ()
    {
        bool checkListIsEmpty = _tankMeshes.TrueForAll (x => x != null);
        if (!checkListIsEmpty)
        {
            Debug.Log ("List Slot Empty");
            return;
        }


        foreach (GameObject Tank in _tankMeshes)
        {
            if (Tank.activeInHierarchy)
            {
                _shotProjectileTransform.Clear ();
                int CountChild = Tank.transform.childCount;
                for (int i = 0; i < CountChild; i++)
                {
                    _shotProjectileTransform.Add (Tank.transform.GetChild (i));
                }
            }
        }
    }

    private bool CheckTankMeshesList (List<GameObject> tankMeshes)
    {
        if (tankMeshes.Count == 0) return false;

        foreach (var item in tankMeshes)
        {
            if (item == null) return false;
        }
        return true;
    }
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    private List<int> temp = new List<int> (); // :)
    public void Attack ()
    {
        foreach (var item in _perkList)
        {
            if (item.TypePerk == PerkType.Defence)
            {
                if (temp.Count == _perkList.Count) break;
                item.Activate (_shooter);
                temp.Add (item.PerkID);
            }

            if (item.TypePerk == PerkType.Offence)
            {
                if (temp.Count == _perkList.Count) break;
                item.Activate (_shooter);
                temp.Add (item.PerkID);
            }
        }

        _shooter.Shooting (_perkList);
        // Медот Для Стрельбы\

    }

    #endregion

    private void AddPerk()
    {
        //if (_perkList.Contains())
        //UpdatePerk
    }

    private void RemovePerk()
    {

    }
}