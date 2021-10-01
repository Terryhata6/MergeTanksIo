using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleStateModel : BasePlayerStateModel
{

    public override void Execute(PlayerController controller, PlayerView player)
    {
        base.Execute(controller, player);
        // Idle
        //Debug.Log("Idle");
    }
}
