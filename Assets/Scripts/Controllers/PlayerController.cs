using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController, IObjectExecuter, IFixedExecute
{
    private PlayerView _player;
    private PlayerView _temp;

    public PlayerView Player => _player;

    #region {Author:Doonn}

    private Vector2 _positionDelta;
    private Vector2 _beganPosition;

    public Vector2 PositionDelta => _positionDelta;
    public Vector2 PositionBegan => _beganPosition;

    #endregion

    private IPlayerState _state;
    private Dictionary<PlayerState, IPlayerState> _stateList = new Dictionary<PlayerState, IPlayerState> ();


    public PlayerController ()
    {
        _stateList.Add (PlayerState.Idle, new PlayerIdleStateModel ());
        _stateList.Add (PlayerState.Move, new PlayerMoveStateModel ());
        _stateList.Add (PlayerState.Attack, new PlayerAttackStateModel ());
    }


    public override void Initialize ()
    {
        _player = GameObject.FindObjectOfType<PlayerView> ();
        if (_player != null)
        {
            Debug.Log (_player.gameObject.name);
        }
        else
        {
            Debug.Log ("Не сработало");
        }

        InputEvents.Current.OnTouchBegan += SetBeganPosition;
        InputEvents.Current.OnTouchEnded += SetIdle;
        InputEvents.Current.OnTouchMoved += SetMove;
    }

    public override void Execute ()
    {
        base.Execute ();
        if (Player == null)
        {
            return;
        }

        switch (Player.State)
        {
            // case PlayerState.Awaiting:
            //     {
            //         _state = _stateList[PlayerState.Awaiting];
            //         break;
            //     }
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
                {
                    //_state = _stateList[PlayerState.Attack];
                    break;
                }
                // case PlayerState.Dead:
                //     _state = _stateList[PlayerState.Dead];
                //     break;
        }

        _player.Attack();
        _state.Execute (this, _player);
    }


    private void SetBeganPosition (Vector2 position)
    {
        _beganPosition = position;
        Debug.Log ("Нажалось");
    }


    public void SetPlayerState (PlayerState state)
    {
        if (_player)
        {
            _player.SetState (state);
        }
    }

    public void SetIdle (Vector2 delta)
    {
        SetPlayerState (PlayerState.Idle);
    }

    public void SetMove (Vector2 delta)
    {
        SetPlayerState (PlayerState.Move);
        _positionDelta = delta;
    }

    public void SetAttack ()
    {
        SetPlayerState (PlayerState.Attack);
    }

    private void PlayerInit(PlayerView player)
    {
        player.gameObject.layer = (int) Layer.Players;
    }
    
    public void AddObj(GameObject obj)
    {
        obj.AddComponent<PlayerView>();
        _temp = obj.GetComponent<PlayerView>();
        _player = _temp;
        PlayerInit(_temp);
        GameEvents.Current.EnvironmentUpdated();
    }
    
}