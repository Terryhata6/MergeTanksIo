using System.Collections.Generic;
using UnityEngine;

public static class LoadPerksSystem
{
    public static readonly string PathPerk = "ScriptablePerks/";
    public static readonly AbstractPerk[] AllPerks;

    static LoadPerksSystem()
    {
        AllPerks = Resources.LoadAll<AbstractPerk>(PathPerk);

        Debug.Log("Статический Конструктор: LoadSystem");
    }

    public static AbstractPerk GetOnePerkByName(string name)
    {
        var perk = Resources.Load<AbstractPerk>(PathPerk + name);
        return perk;
    }

    public static AbstractPerk[] GetAllPerk()
    {
        return AllPerks;
    }



//<< UI
    public static List<AbstractPerk> GetRandomPerkList(int returnCountPerk)
    {
        List<AbstractPerk> perks = new List<AbstractPerk>();

        for (int i = 0; i < returnCountPerk; i++)
        {
            int randomIndex = Random.Range(0, AllPerks.Length-1);
            var getPerkFromIndex = AllPerks[randomIndex];

            if (!perks.Contains(getPerkFromIndex))
            {
                perks.Add(getPerkFromIndex);
            }
            else
            {
                i--;
            }
        }
        return perks;
    }
}