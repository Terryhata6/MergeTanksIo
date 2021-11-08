using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/MoveSpeed", order = 1)]
public class MoveSpeedPerk : AbstractPerk
{
    [SerializeField] private float _speed = 10f; //<< Percentag

    private float _tempPrecentage;

    private MoveSpeedPerk()
    {
        _typePerk = PerkType.Defence;
        _speed = 10f;
    }

    public override void Activate(PlayerView ownPlayer)
    {
        float newSpeed = MoveSpeed(ownPlayer.MovementSpeed);
        ownPlayer.SetMoveSpeed(newSpeed);

    }


    public override void Deactivate(PlayerView ownPlayer)
    {
        float newSpeed = ownPlayer.MovementSpeed - _tempPrecentage;

        ownPlayer.SetMoveSpeed(newSpeed);

    }

    private float MoveSpeed(float speed)
    {
        _tempPrecentage = (speed / 100) * _speed;

        return speed += _tempPrecentage;
    }
}