using UnityEngine;

public class PlayerAttackStateModel : BasePlayerStateModel
{
    public override void Execute (PlayerController controller, PlayerView view)
    {
        base.Execute (controller, view);
        view.Attack ();
    }
}