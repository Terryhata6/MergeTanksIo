using UnityEngine;

public abstract class BasePlayerStateModel : IPlayerState
{
    public virtual void Execute(PlayerController controller, PlayerView view)
    {
        if (!view.State.Equals(PlayerState.Dead))
        {
            // view.PerkManager.ExecutePerks(view.ViewParams);
            // view.Sethehe(view.PerkManager.UpdateViewParamsStruct());
            // TEST
            // foreach (var item in view.Shooter.PerkList)
            {
                // item.Activate(view.Shooter);
            } 
            //<< END
        }
    }
}