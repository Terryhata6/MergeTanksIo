using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AddHealth", menuName = "ScriptableObjects/AddHealth", order = 1)]
public class PerkAddHealth : AbstractPerk
{
    [SerializeField] private float _addhealth = 50f;

    public override void Activate (PlayerView ownPerk)
    {
        //ownPerk.Health = AddHealth (ownPerk.Health);
    }

    private float AddHealth (float health)
    {
        return health += _addhealth;
    }
}