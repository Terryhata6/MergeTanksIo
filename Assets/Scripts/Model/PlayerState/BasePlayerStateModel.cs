using UnityEngine;

public abstract class BasePlayerStateModel : IPlayerState
{
    protected Transform _player;
    public virtual void Execute(PlayerController controller, PlayerView view)
    {
        if (!view.State.Equals(PlayerState.Dead))
        {
            view.UpdateDebuff();
            if (view.PerkManager == null) return;
            view.PerkManager.ExecutePerks(view.ViewParams);

            if (view.NewPerkManager == null) return;
            view.NewPerkManager.NewExecutePerks(view);
        }
    }
}