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
  
  #endregion

  private IPlayerState _state;
  private Dictionary<PlayerState, IPlayerState> _stateList = new Dictionary<PlayerState, IPlayerState>();




  public PlayerController(MainController main)
  {
    _stateList.Add(PlayerState.Idle, new PlayerIdleStateModel());
    _stateList.Add(PlayerState.Move, new PlayerMoveStateModel());
    _stateList.Add(PlayerState.Attack, new PlayerAttackStateModel());
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

  }

  public override void Execute()
  {
    base.Execute();

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
      case PlayerState.Attack:
        _state = _stateList[PlayerState.Attack];
        break;
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

  public void SetIdle(Vector2 delta) 
  {
    SetPlayerState(PlayerState.Idle);
  }

  public void SetMove(Vector2 delta)
  {
    SetPlayerState(PlayerState.Move);
    _positionDelta = delta;
  }

  public void SetAttack()
  {
    SetPlayerState(PlayerState.Attack);
  }
}
