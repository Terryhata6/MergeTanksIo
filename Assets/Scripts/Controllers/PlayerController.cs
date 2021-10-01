using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
  private PlayerView _player;

  public PlayerView Player => _player;

  #region {Author:Doonn}
  private Vector2 _positionDelta = Vector2.zero;
  private Vector2 _beganPosition = Vector2.zero;

  public Vector2 PositionDelta => _positionDelta;
  public Vector2 PositionBegan => _beganPosition;
  private int _currentLevel;
  #endregion

  private IPlayerState _state;
  private Dictionary<PlayerState, IPlayerState> _stateList = new Dictionary<PlayerState, IPlayerState>();


  

  public PlayerController(MainController main)
  {
    _stateList.Add(PlayerState.Idle, new PlayerIdleStateModel());
    _stateList.Add(PlayerState.Move, new PlayerMoveStateModel());
  }


  public override void Initialize()
  {
    _player = GameObject.FindObjectOfType<PlayerView>();
    if (_player != null)
    {
      Debug.Log(_player.gameObject.name);
    }
    else
    {
      Debug.Log("Не сработало");
    }

    InputEvents.Current.OnTouchBegan += SetBeganPosition;
    InputEvents.Current.OnTouchEnded += SetIdle;
    InputEvents.Current.OnTouchMoved += SetMove;

    _currentLevel = Player.Level;
    Player.Test(_currentLevel);
    
  }

  private void gege(int level)
  {
    Debug.Log(level);
  }
  
  public override void Execute()
  {
    base.Execute();

    if(_currentLevel == Player.Level)
    {
      
    } else {
      _currentLevel = Player.Level;
      Player.Test(_currentLevel);
    }



    switch (Player.State)
    {
      case PlayerState.Idle:
        {
          _state = _stateList[PlayerState.Idle];
          break;
        }
      case PlayerState.Move:
        {
          _state = _stateList[PlayerState.Move];
          break;
        }
    }

    _state.Execute(this, _player);

  }


  private void SetBeganPosition(Vector2 position)
  {
    _beganPosition = position;
    Debug.Log("Нажалось");
  }


  public void SetPlayerState(PlayerState state)
  {
    _player.SetState(state);
  }

  // Попахивает Моим Говно Кодом
  public void SetIdle(Vector2 delta) // <<< Не Понятно Зачем Нужен (Vector2 delta)
  {
    SetPlayerState(PlayerState.Idle);
  }
  //..end

  public void SetMove(Vector2 delta)
  {
    SetPlayerState(PlayerState.Move);
    _positionDelta = delta;
  }
}
