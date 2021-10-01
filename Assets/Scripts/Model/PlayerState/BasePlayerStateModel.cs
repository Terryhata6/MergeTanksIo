using UnityEngine;

public abstract class BasePlayerStateModel : IPlayerState
{
    public virtual void Execute(PlayerController controller, PlayerView view)
    {

    }
}
