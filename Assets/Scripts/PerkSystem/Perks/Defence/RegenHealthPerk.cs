using UnityEngine;

[CreateAssetMenu (fileName = "RegenHealth", menuName = "ScriptableObjects/RegenHealth", order = 1)]
public class RegenHealthPerk : AbstractPerk
{
    [SerializeField] private float _regeneration = 1.0f;

    RegenHealthPerk()
    {
        _regeneration = 0.1f;
        _fixedExecute = true;
    }

    public override void Activate (PlayerView ownPlayer)
    {
        if(ownPlayer.Health < ownPlayer.MaxHealth)
        {
            ownPlayer.SetHealth(ownPlayer.Health + _regeneration * Time.fixedDeltaTime);
        }
    }

    public override void Deactivate (PlayerView ownPlayer) 
    { 

    }
}