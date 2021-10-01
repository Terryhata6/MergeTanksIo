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
  [SerializeField, Range(3f, 10f)] private float _movementSpeed = 3.0f;
  //..End
  #endregion


  [SerializeField] private Rigidbody _playerRigidbody;


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

  public void SetState(PlayerState state)
  {
    _state = state;
  }

  // Start is called before the first frame update
  void Start()
  {


  }

  #region {Author:Doonn}
  // Мега ГовноТопКодКостыль
  private int _count = 0;

  public int Count 
  {
    get {
      return _count;
    }
    set{
      if(value != _count){
        DoSomething();
        _count = value;
      }
    }
  }
  

  private static void DoSomething()
  {
    Debug.Log("Test"); 
  }


  public void Test(int level)
  {
    _level = level;

    var Player = GameObject.Find("Player");
    var childCount = Player.gameObject.transform.childCount;
    GameObject[] childs = new GameObject[5];
    for (int i = 0; i < childCount; i++)
    {
      childs[i] = Player.transform.GetChild(i).gameObject;
    }

    for (int i = 0; i < childs.Length; i++)
    {
      var obj = childs[i];
      if (i != Level - 1)
      {
        obj.SetActive(false);
      }
      else
      {
        obj.SetActive(true);
      }
    }

    // if (Level == 1)
    // {

    //   var tanks = Player.transform.GetChild(Level - 1).gameObject;
    //   tanks.SetActive(false);
    // }

    // var tanksCount = Player.gameObject.transform.childCount;
    // if (Level == 1) 
    // {
    //   var tank2 = GameObject.Find("Tank_lvl2");
    //   tank2.SetActive(false);
    // } else {
    //   var tank1 = GameObject.Find("Tank_lvl1");
    //   tank1.SetActive(true);
    // }

    // if (Level == 2) 
    // {
    //   var tank1 = GameObject.Find("Tank_lvl1");
    //   tank1.SetActive(false);
    //   var tank2 = GameObject.Find("Tank_lvl2");
    //   tank2.SetActive(true);
    // }




    // Test Step 1
    // var oldGo = GameObject.Find("Tank_lvl1");
    // var pos = oldGo.transform.position;

    // var newqq = GameObject.Find("Tank_lvl5");

    // var newGo = Instantiate(newqq);
    // newGo.transform.position = pos;
    // newGo.AddComponent<PlayerView>();
    // var tFollowTarget = oldGo.transform;
    // var vcam = GameObject.Find("Main Camera");
    // var ss = vcam.GetComponent<CinemachineBrain>();
    // ss.ActiveVirtualCamera.Follow = newGo.transform;
    // ss.ActiveVirtualCamera.LookAt = newGo.transform;
    //var vcam = GetComponent<CinemachineBrain>();
    //vcam = GetComponent<CinemachineVirtualCamera>();
    //vcam.ActiveVirtualCamera.Follow = newGo.transform;
    // Debug.Log(vcam);

    // var oldCom = oldGo.GetComponent<PlayerView>();
    //Destroy(oldCom);

    //Destroy(oldGo);
  }
  //..End
  #endregion
}
