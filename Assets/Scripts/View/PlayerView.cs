using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerView : BaseObjectView
{

  #region Fields
  [SerializeField] private PlayerState _state = PlayerState.Idle;

  #region {Author:Doonn}
  // Player Level Up
  [SerializeField, Range(1, 5)] private int _level = 1;
  public int Level => _level;

  // Attack Range
  private float _attackRange;
  public float AttackRange => _attackRange;

  // Shot Project Transform
  // Странное Решение Хранить Тут Трансформы << Мб в Коллекцию с танкмешес
  [SerializeField] private List<Transform> _shotProjectileTransform;
  public List<Transform> ShotProjectileTransform => _shotProjectileTransform;
  //..End
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

  public void Awake()
  {
    if (_playerRigidbody == null)
      _playerRigidbody = GetComponent<Rigidbody>();
  }

  // Start is called before the first frame update
  void Start()
  {
    TankShotProjectileRecordTransform();
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

    _tankMeshes[index-1].SetActive(true);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Collectable"))
    {

      if (Level >= 5) return; // Хард Код >> (Level >= 5)

      _level++;
      
      ChangeTankMesh(Level);
      Destroy(other.gameObject);
    }
  }



  #region {Author:Doonn}
  // Запись Трансформов от куда вылетают Снаряды
  private void TankShotProjectileRecordTransform()
  {
    if (_tankMeshes == null) return;
    foreach (var Tank in _tankMeshes)
    {
      int Count = Tank.transform.childCount;
      for (int i = 0; i < Count; i++)
      {
        _shotProjectileTransform.Add(Tank.transform.GetChild(i));
      }
    }
  }
  #endregion
}
