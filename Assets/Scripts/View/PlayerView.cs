using UnityEngine;


public class PlayerView : BasePersonView
{
    [SerializeField] private PlayerState _state = PlayerState.Idle;

    public PlayerState State => _state;

    public void SetState(PlayerState state)
    {
        _state = state;
    }
}