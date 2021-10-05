using UnityEngine;

public class PlayerAttackStateModel : BasePlayerStateModel
{
    public override void Execute(PlayerController controller, PlayerView view) 
    {
        Debug.Log("СТРЕЛЯЮ по МУЭРТОСАМ");
    }
}
