using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerView : BaseObjectView
{
    [SerializeField] private PerkSystem _perkSystem;
    public PerkSystem PerkSystem => _perkSystem;

    #region Fields
    private Shooter _shooter;

    //[Header("MainStats")]
    [SerializeField] private List<AbstractPerk> _perkList;

    [SerializeField] private PlayerState _state = PlayerState.Idle;

    #region {Author:Doonn}

    // Player Level Up
    [SerializeField, Range(1, 5)] private int _level = 1;
    public int Level => _level;

    // Shot Project Transform
    [SerializeField] private List<Transform> _shotProjectileTransform;
    public List<Transform> ShotProjectileTransform => _shotProjectileTransform;

    #endregion

    [SerializeField, Range(3f, 10f)] private float _movementSpeed = 3.0f;

    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private List<GameObject> _tankMeshes;

    #endregion

    #region AccsessModifyers

    public float MovementSpeed => _movementSpeed;


    public PlayerState State => _state;


    public Rigidbody Rigidbody => _playerRigidbody;

    #endregion

    #region Player Stats
    [SerializeField] private float _health;
    public float Health => _health;

    [SerializeField] private float _maxHealth;
    public float MaxHealth => _maxHealth;
    #endregion

    public void Awake()
    {
        if (_playerRigidbody == null)
            _playerRigidbody = GetComponent<Rigidbody>();

        TankShotProjectileRecordTransform();

    }

    // Start is called before the first frame update

    void Start() { }
    //<< Test Perk Add, Remove
    public event Action<PlayerView> ExecutablePerks;
    public void ExecutePerks(PlayerView view)
    {
        ExecutablePerks?.Invoke(view);
    }

 // Test Add Perk
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if (_perkList.Count == 0) return;
            // int lastIndex = _perkList.Count - 1;
            // RemovePerk (lastIndex);
            int lastIndex = _perkSystem.PerkList.Count - 1;
            AbstractPerk newPerk = _perkSystem.PerkList[lastIndex];
            _perkSystem.RemovePerk(newPerk);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // AddPerk (ScriptableObject.CreateInstance<AddHealthPerk> ());
            _perkSystem.AddPerk(ScriptableObject.CreateInstance<AddHealthPerk>());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //AddPerk (ScriptableObject.CreateInstance<AttackSpeedPerk> ());
            _perkSystem.AddPerk(ScriptableObject.CreateInstance<AttackSpeedPerk>());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //AddPerk (ScriptableObject.CreateInstance<SequentialShootsPerk> ());
            _perkSystem.AddPerk(ScriptableObject.CreateInstance<SequentialShootsPerk>());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // AddPerk (ScriptableObject.CreateInstance<RepulsiveProjectilesPerk> ());
            _perkSystem.AddPerk(ScriptableObject.CreateInstance<RepulsiveProjectilesPerk>());

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //AddPerk (ScriptableObject.CreateInstance<RicochetPerk> ());
            _perkSystem.AddPerk(ScriptableObject.CreateInstance<RicochetPerk>());

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //AddPerk (ScriptableObject.CreateInstance<RicochetPerk> ());
            _perkSystem.AddPerk(ScriptableObject.CreateInstance<RegenHealthPerk>());

        }
    }
    //..End
    
    public void InitializeShooter(Shooter shooter)
    {
        _shooter = shooter;
        _perkSystem = new PerkSystem(this, _shooter);
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
        if (other.gameObject.layer == (int)Layer.Collectables)
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
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    public void SetHealth(float health)
    {
        _health = health;
    }
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    public void Attack()
    {
        _shooter.Shooting(_perkSystem.PerkListOnEnable);
    }

    #endregion
}