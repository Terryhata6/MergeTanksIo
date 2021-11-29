using UnityEngine;

public abstract class BasePlayerStateModel : IPlayerState
{
    public virtual void Execute(PlayerController controller, PlayerView view)
    {
        if (!view.State.Equals(PlayerState.Dead))
        {
            if (view.PerkManager == null) return;
            view.PerkManager.ExecutePerks(view.ViewParams);
        }
    }
}