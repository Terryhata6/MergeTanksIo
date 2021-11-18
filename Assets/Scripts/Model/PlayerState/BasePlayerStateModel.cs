using UnityEngine;

public abstract class BasePlayerStateModel : IPlayerState
{
    public virtual void Execute(PlayerController controller, PlayerView view)
    {
        if (view.State != PlayerState.Dead)
        {
            view.PerkManager.ExecutePerks(view.ViewParams);
            
            // TEST
            foreach (var item in view.Shooter.PerkList)
            {
                item.UpdateFixedExecute(view.Shooter);
            } 
            //<< END
        }
    }
}