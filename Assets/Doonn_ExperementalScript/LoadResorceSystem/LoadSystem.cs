using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadSystem
{
    
    public static AbstractPerk LoadPerk(string name)
    {
        string _pathPerk = "ScriptablePerks/" + name;
        var perk = Resources.Load<AbstractPerk>(_pathPerk);
        return perk;
    }
}