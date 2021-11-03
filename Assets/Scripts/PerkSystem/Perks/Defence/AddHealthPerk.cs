using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AddHealth", menuName = "ScriptableObjects/AddHealth", order = 1)]
public class AddHealthPerk : AbstractPerk
{
    [SerializeField] private float _addhealth = 50f;

    public override void Activate (PlayerView ownPlayer)
    {
        ownPlayer.SetHealth(AddHealth (ownPlayer.Health));
    }

    private float AddHealth (float health)
    {
        return health += _addhealth;
    }

    public override void Deactivate (PlayerView ownPlayer)
    {
        ownPlayer.SetHealth(ownPlayer.Health - _addhealth);
    }
}